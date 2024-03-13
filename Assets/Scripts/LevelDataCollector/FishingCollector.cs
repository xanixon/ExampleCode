using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FishingCollector : MonoBehaviour
{
    public int fishHooked
    {
        get;
        private set;
    }
    [Inject]
    public void Construct(BaseFishplaceManager manager)
    {
        manager.OnFishHooked += onFishCaught;
    }

    public override string ToString()
    {
        return $"Рыбы поймано {fishHooked}";
    }
    private void onFishCaught()
    {
        fishHooked++;
    }
}
