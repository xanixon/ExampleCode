using System;
using UnityEngine;

public abstract class BaseFishplacePresenter : MonoBehaviour
{
    public int FishMaxCount { get { return model.FishMaxCount; } }
    public int FishLeft { get { return model.FishLeft; } }

    public Action OnRemoveFish { get { return model.OnRemoveFish; } set { model.OnRemoveFish = value; } }   
    public Action OnFishplaceDeplited { get { return model.OnFishplaceDeplited; } set { model.OnFishplaceDeplited = value; } }
    protected BaseFishplaceView view;
    protected BaseFishplaceModel model;

    public abstract void Init();
}
