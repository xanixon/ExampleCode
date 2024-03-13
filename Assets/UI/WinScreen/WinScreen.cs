using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public abstract class WinScreen : MonoBehaviour
{
    [SerializeField] protected TMP_Text winText;
    [SerializeField] protected TMP_Text rewardText;
    protected string nextLevelName;
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
    public abstract void SetUp(string nextLevelName, string winMessage, int moneyReward);
    public class Factory : PlaceholderFactory<WinScreen> { }
}
