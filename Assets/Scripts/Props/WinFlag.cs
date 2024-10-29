using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    [SerializeField] private GameEvent OnPlayerWon;
    private float timer = 3;

    private void OnTriggerStay2D(Collider2D other) {
        if (timer != 0) {
            StartCoroutine(decreaseTimer());
        } else {
            OnPlayerWon.Raise();
            GameManager.Instance.ChangeState(GameState.Winning);
            print("you win");
        }
    }

    private IEnumerator decreaseTimer() {
        yield return new WaitForSeconds(1);
        timer -= 1;
    }
}
