using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField]
    private TMP_Text killsText,
                     fishHookedText;


    public void SetUp(PlayerLevelResult data)
    {
        killsText.text = data.EnemyKilled.ToString();
        fishHookedText.text = data.FishHooked.ToString();
    }

    public void Restart()
    {
        if (sceneIndex > 0)
            SceneManager.LoadScene(sceneIndex);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }

    public class Factory: PlaceholderFactory<GameOverScreen> { }
}
