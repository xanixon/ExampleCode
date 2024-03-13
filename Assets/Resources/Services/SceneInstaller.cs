using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private QuestHolder questHolderInstance;
    [SerializeField] private WinScreen winScreenPrefab;
    [SerializeField] private TriggerZone endLevelTrigger;
    [SerializeField] private BaseQuestBinder questBinder;
    public override void InstallBindings()
    {
        Container.BindInstance(questHolderInstance).AsSingle();
        Container.BindInstance(endLevelTrigger).WithId("EndLevel").AsSingle();

        Container.BindFactory<WinScreen, WinScreen.Factory>().FromComponentInNewPrefab(winScreenPrefab);

        Container.Bind<BaseQuestBinder>().FromComponentInNewPrefab(questBinder).AsSingle().Lazy();
    }
}
