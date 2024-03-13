using UnityEngine;
using Zenject;

public class KillsCollector : MonoBehaviour
{
    public int enemyKilled
    {
        get; 
        private set;
    }
    [Inject]
    public void Construct(BaseEnemyManager enemyManager)
    {
        enemyManager.OnEnemyKilled += onEnemyKill;
    }

    public override string ToString()
    {
        return $"Акулов наказно: {enemyKilled}";
    }
    private void onEnemyKill(BaseHealth victim)
    {
        enemyKilled++;
    }
}
