using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private GameObject player;
    [SerializeField] private BaseCompass playerCompass;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private BaseFishingView fishingHandler;
    [SerializeField] private QuestProgressPanel questProgress;
    [SerializeField] private BaseFishplaceManager fishplaceManager;
    [SerializeField] private BaseEnemyManager enemyManager;
    [SerializeField] private FishingCollector fishingCollector;
    [SerializeField] private KillsCollector killsCollector;
    [SerializeField] private BaseSavegameManager savegameManager;
    [SerializeField] private UpgradesHandler upgradesHandler;
    [SerializeField] private UpgradeShop shop;
    [SerializeField] private PlayerMoney playerMoney;
    [SerializeField] private PauseHandler pauseHandler;
    
    public override void InstallBindings()
    {
        Container.Bind<InputHandler>().FromComponentInNewPrefab(inputHandler).AsSingle().Lazy();
        Container.Bind<PlayerHealth>().FromComponentInNewPrefab(player).AsSingle().Lazy();
        Container.Bind<BaseCompass>().FromComponentInNewPrefab(playerCompass).AsSingle().Lazy();
        Container.Bind<CameraController>().FromComponentInNewPrefab(cameraController).AsSingle().Lazy();

        Container.Bind<BaseFishingView>().FromComponentInNewPrefab(fishingHandler).AsSingle().Lazy();
        Container.Bind<QuestProgressPanel>().FromComponentInNewPrefab(questProgress).AsSingle().Lazy();
        Container.Bind<BaseFishplaceManager>().FromComponentInNewPrefab(fishplaceManager).AsSingle().Lazy();
        Container.Bind<BaseEnemyManager>().FromComponentInNewPrefab(enemyManager).AsSingle().Lazy();

        Container.Bind<FishingCollector>().FromComponentInNewPrefab(fishingCollector).AsSingle().Lazy();
        Container.Bind<KillsCollector>().FromComponentInNewPrefab(killsCollector).AsSingle().Lazy();
        Container.Bind<BaseSavegameManager>().FromComponentInNewPrefab(savegameManager).AsSingle().Lazy();
        Container.Bind<UpgradesHandler>().FromComponentInNewPrefab(upgradesHandler).AsSingle().Lazy();
        Container.Bind<UpgradeShop>().FromComponentInNewPrefab(shop).AsSingle().Lazy();
        Container.Bind<PlayerMoney>().FromComponentInNewPrefab(playerMoney).AsSingle().Lazy();
        Container.Bind<PauseHandler>().FromComponentInNewPrefab(pauseHandler).AsSingle().Lazy();

    }
}