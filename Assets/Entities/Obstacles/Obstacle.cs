using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    private GameOverHandler _gameOverHandler;


    [Inject]
    public void Construct(GameOverHandler gameOverHandler)
    {
        _gameOverHandler = gameOverHandler;
    }
    private void OnTriggerEnter(Collider other)
    {
        _gameOverHandler.GameOver();
    }

    public class Factory : PlaceholderFactory<Obstacle> { }
}
