using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public int Score { get; private set; }
    public event Action<int> OnScoreChanged;
    public void AddScore(int value)
    {
        if (value < 0) return;
        Score += value;
        OnScoreChanged?.Invoke(Score);
    }

    public void CleanUp()
    {
        Score = 0;
    }
}
