using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCollision : MonoBehaviour
{
    [SerializeField] private Collider2D collision;

    public void OnPlayerStateChanged(Component _component, object _data) {
        if (_data is PlayerState) {
            PlayerState _state = (PlayerState) _data;
            if (_state == PlayerState.Alive) {
                collision.enabled = true;
            } else if (_state == PlayerState.Ghost) {
                collision.enabled = false;
            }
        }
    }
}
