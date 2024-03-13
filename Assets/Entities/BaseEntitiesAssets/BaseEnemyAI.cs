using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BaseHealth))]
public class BaseEnemyAI : MonoBehaviour
{
    [Inject]
    public void Construct(BaseEnemyManager enemyManager)
    {
        BaseHealth h = GetComponent<BaseHealth>();
        enemyManager.RegisterEnemy(h);
    }

}
