using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFishplaceManager : MonoBehaviour
{
    public event Action OnFishHooked;
    private List<FishplacePresenter> _fishplaces = new List<FishplacePresenter>();
    public virtual void RegisterFishplace(FishplacePresenter fishplace)
    {
        fishplace.OnRemoveFish += onFishHooked;
        _fishplaces.Add(fishplace);
    }

    protected virtual void onFishHooked()
    {
        OnFishHooked?.Invoke();
    }
}
