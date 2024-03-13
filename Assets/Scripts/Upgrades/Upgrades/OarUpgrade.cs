using UnityEngine;

[CreateAssetMenu(fileName = "OarUpgrade", menuName = "Custom/OarUpgrade")]
public class OarUpgrade : BaseUpgrade
{
    public float BonusDamage;
    public float BonusRadius;
    public override SavableConfig ApplyUpgrade(BoatFitter fitter)
    {
        OarConfig config = fitter.Oar;
        config.OarPurchased = true;
        config.BonusDamage += BonusDamage;
        config.BonusRadius += BonusRadius;
        return config;
    }
}
