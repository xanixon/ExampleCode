using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected bool saveProgress = true;
    [SerializeField] protected string NextLevelName;
    [SerializeField] protected string winText = "";
    protected WinScreen.Factory winScreenFactory;
    protected GameObject player;
    protected CameraController cameraController;
    protected GameOverScreen.Factory gameOverScreenFactory;
    protected InputHandler inputHandler;
    protected KillsCollector killsCollector;
    protected FishingCollector fishingCollector;
    protected BaseSavegameManager savegameManager;
    protected QuestHolder questHolder;
    protected BaseQuestBinder questBinder;
    protected PlayerMoney money;

    [Inject]
    public void Construst(PlayerHealth player, 
                          InputHandler input,
                          CameraController cameraController,
                          GameOverScreen.Factory gameOverFactory, 
                          WinScreen.Factory winFactory,
                          QuestProgressPanel questProgress,
                          QuestHolder holder,
                          BaseQuestBinder binder,
                          KillsCollector killsCollector,
                          FishingCollector fishingCollector,
                          BaseSavegameManager savegame,
                          PlayerMoney money)
    {
        this.player = player.gameObject;
        BaseHealth playerHealth = this.player.GetComponent<BaseHealth>();
        playerHealth.DeathEvent += gameOverHandler;

        this.inputHandler = input;
        this.cameraController = cameraController;

        this.winScreenFactory = winFactory;
        this.gameOverScreenFactory = gameOverFactory;
        this.questHolder = holder;        
        this.questBinder = binder;
        this.questBinder.OnLevelComplete += winHandler;
        this.killsCollector = killsCollector;
        this.fishingCollector = fishingCollector;
        this.savegameManager = savegame;
        savegameManager.SetLevelsProgress(SceneManager.GetActiveScene().buildIndex);
        this.money = money;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        buildPlayer();
        buildEnvironment();
        buildEnemies();
    }

    protected virtual void buildPlayer()
    {
        cameraController.SetTarget(player.transform);
    }

    protected void buildEnvironment()
    {
       
    }
    protected virtual void buildEnemies()
    {
       
    }

    protected void gameOverHandler(BaseHealth playerHealth)
    {
        inputHandler.enabled = false;
        PlayerLevelResult levelData = new PlayerLevelResult(fishingCollector.fishHooked, killsCollector.enemyKilled);
        GameOverScreen gos = gameOverScreenFactory.Create();
        gos.SetUp(levelData);
    }

    protected void winHandler()
    {
        int levelTotalReward = questHolder.GetReward();
        money.AddMoney(levelTotalReward);

        WinScreen screen = winScreenFactory.Create();        
        screen.SetUp(NextLevelName, winText, levelTotalReward);

        if (saveProgress)
        {
            int levelIndex = SceneUtility.GetBuildIndexByScenePath($"Assets/Scenes/{NextLevelName}.unity");
            savegameManager.SetLevelsProgress(levelIndex);
            savegameManager.SaveGame();
        }
    }

    public class Factory : PlaceholderFactory<GameManager> { }

}
