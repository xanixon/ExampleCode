using TMPro;
using UnityEngine;

public class CompassArrow : BaseCompassArrow
{
    public override float DistanceToMarker
    {
        set
        {
            distanceTextbox.text = $"{value.ToString("F0")} ì";
        }
    }
    public override string MarkerText
    {
        set
        {
            markerLabelTextbox.text = value;
        }
    }
    [SerializeField] protected TMP_Text distanceTextbox;
    [SerializeField] protected TMP_Text markerLabelTextbox;

    public override void HideMarker()
    {
        distanceTextbox.gameObject.SetActive(false);
        distanceTextbox.gameObject.SetActive(false);
    }

    public override void ShowMarker()
    {
        distanceTextbox.gameObject.SetActive(true);
        distanceTextbox.gameObject.SetActive(true);
    }

}
