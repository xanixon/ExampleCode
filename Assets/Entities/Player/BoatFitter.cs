using System.Collections.Generic;
using UnityEngine;

public class BoatFitter : MonoBehaviour
{
    public BoatMotorConfig Motor = new BoatMotorConfig();
    public OarConfig Oar = new OarConfig();
    
    [SerializeField] private BoatMotor _boatMotor;
    [SerializeField] private OarHandler _oarHandler;

    public void ResetUpgrades()
    {
        Motor = new BoatMotorConfig();
        Oar = new OarConfig();
    }

    public void ApplyConfigs()
    {
        _boatMotor.SetConfig(Motor);
        _oarHandler.SetConfig(Oar);
    }  
}
