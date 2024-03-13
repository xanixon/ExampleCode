using System;

[Serializable]
public class OarConfig: SavableConfig
{
    public bool OarPurchased;
    public float BonusDamage;
    public float BonusRadius;

    public OarConfig() { }
    public OarConfig(float bonudDamage, float bonudRadius, bool oarPurchased)
    {
        BonusDamage = bonudDamage;
        BonusRadius = bonudRadius;
        OarPurchased = oarPurchased;
    }
}
