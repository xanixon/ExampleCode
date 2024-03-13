using System;
public abstract class BaseFishplaceModel
{
    public int FishLeft { get { return _fishLeft; } protected set { _fishLeft = value; } }
    public int FishMaxCount { get { return _fishStartCount; } protected set { _fishStartCount = value; } }

    public Action OnFishplaceDeplited;
    public Action OnRemoveFish;

    private int _fishStartCount = 4;
    private int _fishLeft;

    public abstract void RemoveFish();
}