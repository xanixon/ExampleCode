using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFishingPresenter : MonoBehaviour
{
    public bool fishingInProgress { get { return model.fishingInProgress; } }
    public bool hasFishplace { get { return model.fishplaceView != null;  } }
    protected virtual BaseFishingView view { get; set; }
    protected virtual BaseFishingModel model { get; set; }


    protected abstract void setFishplace(BaseFishplaceView fishplace);
    protected abstract void restart();
    protected abstract void hookTheFish();
    protected abstract void startFishing();
    protected abstract void stopFishing();
}
