using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishingBobberView : BaseFishingView
{
    protected override BaseFishingPresenter presenter 
    {
        get => bobberPresenter; 
        set
        {
            bobberPresenter = value is FishingBobberPresenter ? 
                (FishingBobberPresenter)value : 
                null;
        }
    }

    protected FishingBobberPresenter bobberPresenter;
    public override void Init(BaseFishingPresenter presenter)
    {
        this.presenter = (FishingBobberPresenter)presenter;
    }
}
