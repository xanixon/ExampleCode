using System;

public abstract class BaseFishingModel 
{
    
    public bool fishingInProgress 
    {
        get { return _fishingInProgress; } 
        set
        {
            _fishingInProgress = value;
            OnFishingStartEnd?.Invoke(_fishingInProgress);
        }
    }
    public int FishMaxCount { get { return _fishplacePresenter.FishMaxCount; } }
    public int FishLeft { get { return _fishplacePresenter.FishLeft; } }
    public BaseFishplaceView fishplaceView { get; protected set; }
    public Action<bool> OnFishingStartEnd;
    public Action OnRemoveFish { get { return _fishplacePresenter.OnRemoveFish; } set { _fishplacePresenter.OnRemoveFish = value; } }
    public Action OnFishplaceDeplited { get { return _fishplacePresenter.OnFishplaceDeplited; } set { _fishplacePresenter.OnFishplaceDeplited = value; } }
    private BaseFishplacePresenter _fishplacePresenter;
    private bool _fishingInProgress;
    
    
   

    public void SetFishplace(BaseFishplaceView newFishplace)
    {
        dropFishplace();
        if (newFishplace != null)
        {
            _fishplacePresenter = newFishplace.presenter;
        }
        this.fishplaceView = newFishplace;
    }

    public void RemoveFish()
    {
        fishplaceView.RemoveFish();
    }
    protected void dropFishplace()
    {
        if (_fishplacePresenter != null) 
        {
            _fishplacePresenter.OnFishplaceDeplited -= dropFishplace;
        }
        _fishplacePresenter = null;
        fishplaceView = null;
    }
}
