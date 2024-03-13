using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerLevelResult 
{
    public int FishHooked;
    public int EnemyKilled;

    public PlayerLevelResult(int fishHooked, int enemyKilled)
    {
        FishHooked = fishHooked;
        EnemyKilled = enemyKilled;
    }
}
