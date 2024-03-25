using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject _vobla;
    public override void InstallBindings()
    {
        Container.BindInstance(_vobla).WithId("Vobla").AsSingle();
    }
}
