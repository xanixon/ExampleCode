using TMPro;
using UnityEngine;
using Zenject;

public class BaseCompassMarker : MonoBehaviour
{
    public float DistanceToCompass { get; set; }
    public string MarkerLabel;
    private BaseCompass _compass;

    [Inject]
    public void Construct(BaseCompass compass)
    {
        _compass = compass;        
    }

    private void Start()
    {
        _compass.Register(this);
    }

    public override string ToString()
    {
        return MarkerLabel;
    }

    private void OnDestroy()
    {
        _compass.Unregister(this);
    }
}
