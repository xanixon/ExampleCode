using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyManager : MonoBehaviour
{
    public Action<BaseHealth> OnEnemyKilled;
    private List<BaseHealth> _enemies = new List<BaseHealth>();
    public void RegisterEnemy(BaseHealth enemyHealth)
    {
        enemyHealth.DeathEvent += onEnemyDeath;
        _enemies.Add(enemyHealth);
    }

    protected void onEnemyDeath(BaseHealth health)
    {
        OnEnemyKilled?.Invoke(health);
    }
}
