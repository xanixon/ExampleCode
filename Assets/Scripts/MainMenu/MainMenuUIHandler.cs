using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIHandler : MonoBehaviour 
{
    [SerializeField] private string _firstLevelName;
    [SerializeField] private int _levelProgress;
    [SerializeField] private Animator _cameraAnim;
    [SerializeField] private GameObject _levelSelector,
                                        _mainMenuPanel;
    [SerializeField] private LevelSelectorHandler _levelSelectorHandler;
    [SerializeField] private SavegameManager _savegameManager;
    [SerializeField] private Button _continueBtn;
    // Start is called before the first frame update
    void Start()
    {
        _levelProgress = _savegameManager.GetCurrentLevelIndex();
        _continueBtn.interactable = _savegameManager.HasSavedProgress;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        _savegameManager.ClearSaveFile();
        SceneManager.LoadScene(_firstLevelName);
    }

    public void Continue()
    {
        SceneManager.LoadScene(_levelProgress);
    }

    public void OpenLevelSelector()
    {
        _levelSelector.SetActive(true);
        _mainMenuPanel.SetActive(false);        
        _levelSelectorHandler.Init(_levelProgress);
        _cameraAnim.SetBool("LookAtFishes", true);
    }

    public void CloseLevelSelector()
    {
        _levelSelector.SetActive(false);
        _mainMenuPanel.SetActive(true);
        _continueBtn.interactable = _savegameManager.HasSavedProgress;
        _cameraAnim.SetBool("LookAtFishes", false);
    }
}
