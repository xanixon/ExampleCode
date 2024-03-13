using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class VisitPlaceQuest : BaseQuest
{
    [SerializeField] private TriggerZone _triggerZone;

    public VisitPlaceQuest()
    {
        TaskText = "посетить место";
    }
    public override void Init()
    {
        maxProgress = 1;
        trackTriggerZone();
    }
    public void SetTriggerZone(TriggerZone newTriggerZone)
    {
        _triggerZone = newTriggerZone;
    }
    public override string GetProgressText()
    {
        return Progress < 1 ? "" : "Завершено";
    }

    protected void trackTriggerZone()
    {
        if(_triggerZone == null) { throw new Exception($"Не назначена триггер-зона для VisitPlaceQuest <{TaskText} {GetProgressText()}>"); }
        _triggerZone.TriggerEnteredHandler += onPlaceVisited;
    }

    protected void onPlaceVisited()
    {
        AddProgress(1);
    }
}
