using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaterCollector : MonoBehaviour
{
    private ScoreHandler _score;
    [Inject]
    public void Construct(ScoreHandler score)
    {
        _score = score;
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject waterDrop = other.gameObject;
        if(waterDrop.layer == 4) //water layer
        {
            _score.AddScore(1);
            waterDrop.SetActive(false);
        }
    }
}
