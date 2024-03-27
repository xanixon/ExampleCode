using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private TMP_Text _scoreText;
    private WorldMotor _motor;
    private ScoreHandler _scoreHandler;

    [Inject]
    public void Construct(WorldMotor motor, ScoreHandler score)
    {
        _motor = motor;
        _scoreHandler = score;
    }
    
    public void GameOver()
    {
        _loosePanel.SetActive(true);
        _scoreText.text = _scoreHandler.Score.ToString();
        
        _motor.isRunning = false;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        _loosePanel.SetActive(false);
        _motor.CleanUp();
        _scoreHandler.CleanUp();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
