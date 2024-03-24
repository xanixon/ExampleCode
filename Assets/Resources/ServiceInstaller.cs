using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private WorldMotor _worldMotor;
    [SerializeField] private SceneObjectsSpawner _decorationSpawner;
    [SerializeField] private SceneObjectsSpawner _waterSpawner;
    [SerializeField] private ScoreHandler _scoreHandler;
    public override void InstallBindings()
    {
        Container.Bind<WorldMotor>().FromComponentInNewPrefab(_worldMotor).AsSingle().Lazy();
        Container.Bind<SceneObjectsSpawner>().WithId("DecorationsSpawner").FromComponentInNewPrefab(_decorationSpawner).AsCached().Lazy();
        Container.Bind<SceneObjectsSpawner>().WithId("WaterSpawner").FromComponentInNewPrefab(_waterSpawner).AsCached().Lazy();
        Container.Bind<ScoreHandler>().FromComponentInNewPrefab(_scoreHandler).AsSingle().Lazy();
    }
}