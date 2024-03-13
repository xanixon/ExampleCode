using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFishplaceView : MonoBehaviour
{
    public abstract int FishMaxCount { get; }
    public Action OnViewRemoveFish;
    public BaseFishplacePresenter presenter { get; protected set; }

    public abstract void UpdateView(int newCount);
    public abstract void RemoveFish();

    public virtual void Init(BaseFishplacePresenter presenter) { this.presenter  = presenter; }
}
