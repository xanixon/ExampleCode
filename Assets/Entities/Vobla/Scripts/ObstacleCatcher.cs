using UnityEngine;
using Zenject;

public class ObstacleCatcher : MonoBehaviour
{
    private GameOverHandler _gameOver;

    [Inject]
    public void Construct(GameOverHandler gameOver)
    {
        _gameOver = gameOver;
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameOver.GameOver();
    }
}
