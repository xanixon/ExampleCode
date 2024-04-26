using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private WorldMotor _worldMotor;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private SceneObjectsSpawner _decorationSpawner;
    [SerializeField] private SceneObjectsSpawner _waterSpawner;
    [SerializeField] private SceneObjectsSpawner _obstacleSpawner;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private BaseUIHint _baseUIHint;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private GameOverHandler _gameOverHandler;
    [SerializeField] private PauseHandler _pauseHandler;

    [SerializeField] private BrokenBeerMug _brokenBeer;

    public override void InstallBindings()
    {
        Container.Bind<WorldMotor>().FromComponentInNewPrefab(_worldMotor).AsSingle().Lazy();
        Container.Bind<InputHandler>().FromComponentInNewPrefab(_inputHandler).AsSingle().Lazy();
        Container.Bind<SceneObjectsSpawner>().WithId("DecorationsSpawner").FromComponentInNewPrefab(_decorationSpawner).AsCached().Lazy();
        Container.Bind<SceneObjectsSpawner>().WithId("WaterSpawner").FromComponentInNewPrefab(_waterSpawner).AsCached().Lazy();
        Container.Bind<SceneObjectsSpawner>().WithId("ObstacleSpawner").FromComponentInNewPrefab(_obstacleSpawner).AsCached().Lazy();
        Container.Bind<ScoreHandler>().FromComponentInNewPrefab(_scoreHandler).AsSingle().Lazy();
        Container.Bind<BaseUIHint>().FromComponentInNewPrefab(_baseUIHint).AsSingle().Lazy();
        Container.Bind<CameraController>().FromComponentInNewPrefab(_cameraController).AsSingle().Lazy();
        Container.Bind<GameOverHandler>().FromComponentInNewPrefab(_gameOverHandler).AsSingle().Lazy();
        Container.Bind<PauseHandler>().FromComponentInNewPrefab(_pauseHandler).AsSingle().Lazy();
    }
}