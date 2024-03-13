using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFishingView : MonoBehaviour
{
    public Action<BaseFishplaceView> OnFishplaceSet;
    public event Action HookEventHandler;
    public event Action StartFishingEventHandler;
    protected virtual BaseFishingPresenter presenter { get; set; }
   
    public virtual void Init(BaseFishingPresenter presenter) { this.presenter = presenter; }
    public abstract void UpdateView();
    public abstract void UpdateFishUI(int fishLeft, int maxFish);
    public abstract void ToggleFishingObject(bool isFishingStarted);
    public abstract void SetFishplace(BaseFishplaceView fishplace);
    public virtual void OnHook()
    {
        HookEventHandler?.Invoke();
    }
    public virtual void OnStartFishing()
    {
        StartFishingEventHandler?.Invoke();
    }
}
