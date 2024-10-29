using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private Sprite aliveSprite;
    [SerializeField] private Sprite ghostSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnPlayerStateChanged(Component _comp, object _data) {
        if (_data is PlayerState) {
            PlayerState _state = (PlayerState) _data;

            switch (_state) {
                case PlayerState.Alive:
                    spriteRenderer.sprite = aliveSprite;
                    break;
                case PlayerState.Ghost:
                    spriteRenderer.sprite = ghostSprite;
                    break;
            }
        }
    }
}
