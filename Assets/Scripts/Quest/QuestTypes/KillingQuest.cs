using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingQuest : BaseQuest
{
    [SerializeField] private List<BaseHealth> targets = new List<BaseHealth>();

    public KillingQuest()
    {
        TaskText = "квест на убийство";
    }
    public override void Init()
    {
        trackTargets();
    }
    public override string GetProgressText()
    {
        return $"{(int)Progress}/{maxProgress}";
    }

    protected void trackTargets()
    {
        maxProgress = targets.Count;
        foreach(BaseHealth target in targets) 
        {
            if (target == null) { throw new Exception($"Не назначена одна из целей убийства квеста <{TaskText} {GetProgressText()}>"); }
            target.DeathEvent += onQuestTargetKill;
        }
    }

    private void onQuestTargetKill(BaseHealth health)
    {
        AddProgress(1);
    }
}
