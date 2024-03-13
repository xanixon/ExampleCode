using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCompass: MonoBehaviour
{
    public abstract void Register(BaseCompassMarker newMarker);
    public abstract void Unregister(BaseCompassMarker newMarker);
    protected abstract void updateArrows();

}
