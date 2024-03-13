using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingQuest : BaseQuest
{
    [SerializeField] private int fishToHook = 1;
    [SerializeField] private List<FishplacePresenter> fishplaces;
    public FishingQuest()
    {
        TaskText = "квест на рыбалку";
    }

    public override void Init()
    {
        trackFishplaces();
    }
    public override string GetProgressText()
    {
        return $"{(int)Progress}/{maxProgress}";
    } 
    
    protected void trackFishplaces()
    {
        maxProgress = fishToHook;
        foreach(var fishplace in fishplaces)
        {
            fishplace.OnRemoveFish += onFishHooked;
        }
    }

    protected void onFishHooked()
    {
        AddProgress(1);
    }
}
