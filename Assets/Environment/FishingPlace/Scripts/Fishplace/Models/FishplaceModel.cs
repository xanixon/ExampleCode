using System.Collections;
using System;
using UnityEngine;

public class FishplaceModel: BaseFishplaceModel
{
    public FishplaceModel(int fishCount)
    {
        FishMaxCount = fishCount;
        FishLeft = fishCount;
    }

    public override void RemoveFish()
    {
        FishLeft--;
        if (FishLeft <= 0) 
            OnFishplaceDeplited?.Invoke();        
        OnRemoveFish?.Invoke();
    }
}
