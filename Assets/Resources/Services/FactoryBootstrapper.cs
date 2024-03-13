using UnityEngine;
using Zenject;

public class FactoryBootstrapper : MonoInstaller
{
    [SerializeField] private GameOverScreen gameOverScreenPrefab;
    [SerializeField] private FishplacePresenter fishplacePrefabSize4;
    [SerializeField] private GameManager gameManagerPrefab;    
    public override void InstallBindings()
    {
        Container.BindFactory<GameOverScreen, GameOverScreen.Factory>().FromComponentInNewPrefab(gameOverScreenPrefab).AsSingle();
        Container.BindFactory<FishplacePresenter, FishplacePresenter.Factory>().FromComponentInNewPrefab(fishplacePrefabSize4);        
    }
}