using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using Zenject;

public class QuestHolder: MonoBehaviour, ICheated
{
    public Action<QuestHolder> OnQuestListUpdate;
    [SerializeReference] public List<BaseQuest> quests = new List<BaseQuest>();

    protected virtual void Awake()
    {
        Init();
    }

    public void Init()
    {
        foreach (var baseQuest in quests)
        {
            baseQuest.Init();
        }
    }

    public void AddQuest(BaseQuest baseQuest)
    {
        quests.Add(baseQuest);
        OnQuestListUpdate?.Invoke(this);
    }

    public int GetReward()
    {
        int result = 0;
        foreach(var baseQuest in quests)
        {
            if (baseQuest.Progress >= baseQuest.maxProgress)
                result += baseQuest.MoneyReward;
        }
        return result;
    }

    public void Cheat()
    {
        for (int i = quests.Count - 1; i >= 0; i--)
        {
            quests[i].Cheat();
        }
    }
}
