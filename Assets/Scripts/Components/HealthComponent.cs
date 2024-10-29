using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }

    [Header("Events")]
    public UnityEvent<GameObject> OnTakeHit;
    public UnityEvent<GameObject> OnDie;

    private void Start() {
        if (maxHealth <= 0) return;
        
        MaxHealth = maxHealth;
        Health = maxHealth;
    }

    public void TakeDamage(int amount, GameObject entity) {
        OnTakeHit?.Invoke(entity);

        Health = Mathf.Max(0, Health - amount);

        if (Health <= 0) {
            OnDie?.Invoke(entity);
        }
    }
    public void HealHealth(int amount) {
        Health = Mathf.Min(maxHealth, Health + amount);
    }
    public void SetMaxHealth(int amount) {
        MaxHealth = amount;
        Health = amount;
    }
}
