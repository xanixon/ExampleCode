using System;
using UnityEngine;
using Zenject;

public abstract class BaseQuestBinder : MonoBehaviour
{    
    public Action OnLevelComplete;
    protected QuestHolder questHolder;
    protected int questCount;
    protected int completedQuests = 0;

    [Inject]
    public virtual void Construct(QuestHolder holder)
    {
        questHolder = holder;
        bindQuests(holder);
    }

    protected virtual void onQuestComplited(BaseQuest quest)
    {
        completedQuests++;
        if (completedQuests >= questCount)
        {
            OnLevelComplete?.Invoke();
        }
    }

    protected void bindQuests(QuestHolder holder)
    {
        this.questHolder = holder;
        questCount = questHolder.quests.Count;
        foreach (BaseQuest q in questHolder.quests)
        {
            q.OnWin += onQuestComplited;
        }
    }
}
