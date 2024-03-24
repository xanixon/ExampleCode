using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private WorldMotor _worldMotor;
    public override void InstallBindings()
    {
        Container.Bind<WorldMotor>().FromComponentInNewPrefab(_worldMotor).AsSingle().Lazy();
    }
}