using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerState currentPlayerState;
    [SerializeField] private GameEvent OnPlayerStateChanged;

    private HealthComponent healthComponent;

    private void Awake() {
        healthComponent = GetComponent<HealthComponent>();
    }

    public void Die() {

        switch (currentPlayerState) {
            case PlayerState.Alive:
                currentPlayerState = PlayerState.Ghost;
                healthComponent.HealHealth(1);
                break;
            case PlayerState.Ghost:
                print("Died");
                break;
        }

        OnPlayerStateChanged.Raise(this, PlayerState.Ghost);
    }

    public void Revive() {
        currentPlayerState = PlayerState.Alive;

        OnPlayerStateChanged.Raise(this, PlayerState.Alive);
    }
}

public enum PlayerState {
    Alive,
    Ghost
}