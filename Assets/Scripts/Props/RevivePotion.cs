using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<Player>(out Player _player)) {
            _player.Revive();
            Destroy(gameObject);
        }
    }
}
