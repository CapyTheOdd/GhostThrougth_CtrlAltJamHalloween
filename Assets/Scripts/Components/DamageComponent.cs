using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private string filterTag;

    private void OnCollisionEnter2D(Collision2D other) {
        Damage(other.collider);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Damage(other);
    }

    private void Damage(Collider2D other) {
        if (filterTag != "")
        {
            if (!other.gameObject.CompareTag(filterTag)) return;
        }

        if (other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent Health)) {
            Health.TakeDamage(damage, gameObject);
        }
    }

    public void SetDamage(int _amount) {
        damage = _amount;
    }
}

enum DamageType {
    OneHit,
    MultiHit
}