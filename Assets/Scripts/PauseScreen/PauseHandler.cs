using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    public bool Paused
    {
        get { return _paused; }
        private set
        {
            _paused = value;
            _uiPanel.SetActive(_paused);
            Time.timeScale = _paused ? 0 : 1;
        }
    }
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private string _mainMenuSceneName;
    private bool _paused;
    public void TogglePause()
    {
        Paused = !Paused;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneName);
        Paused = false;
    }

    private void OnDestroy()
    {
        if (Paused) Paused = false;
    }
}
