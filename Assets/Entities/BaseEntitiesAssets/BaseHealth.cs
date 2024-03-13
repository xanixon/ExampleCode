using System;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour
{
    public float CurrentHealthForInspector;

    public float CurrentHealth
    {
        get { return _currentHealth; }
        protected set
        {
            _currentHealth = value;
            CurrentHealthForInspector = _currentHealth;
            if (_currentHealth <= 0)
            {
                isAlive = false;
                DeathEvent?.Invoke(this);
            }
        }
    }
    public float MaxHealth { get; protected set; }
    public float HealthRegen { get; protected set; }
    public bool isAlive
    {
        get { return _isAlive; }
        protected set { _isAlive = value; }
    }

    public event Action<BaseHealth> DeathEvent;
    public event Action<float> OnDamageTaken;
    public event Action<float> OnHealing;
    public event Action SetUpEventHandler;

    protected float _currentHealth;
    protected float totalStunTime;
    private bool _isAlive;

    public virtual void SetUp(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
        HealthRegen = 0;
        isAlive = true;
        SetUpEventHandler?.Invoke();
    }

    public virtual float TakeDamage(float damage)
    {
        if (damage <= 0) return damage;

        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        OnDamageTaken?.Invoke(damage);
        return damage;
    }

    public virtual void Heal(float value)
    {
        if (value <= 0) return;

        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, MaxHealth);
        OnHealing?.Invoke(value);
    }

}
