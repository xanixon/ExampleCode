using UnityEngine;
using Zenject;

public class TutorialOarFitter : MonoBehaviour
{
    public BaseUpgrade OarUpgrade;
    private BoatFitter _fitter;

    [Inject]
    public void Conctruct(PlayerHealth player)
    {
        _fitter = player.GetComponent<BoatFitter>();    
    }
    private void OnTriggerStay(Collider other)
    {
        OarConfig oarConfig = new OarConfig(0, 0, true);
        _fitter.Oar = oarConfig;
        _fitter.ApplyConfigs();
        gameObject.SetActive(false);
    }
}
