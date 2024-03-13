using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCompassArrow : MonoBehaviour
{
    public abstract float DistanceToMarker { set; }
    public abstract string MarkerText { set; }
    public abstract void HideMarker();
    public abstract void ShowMarker();
}
