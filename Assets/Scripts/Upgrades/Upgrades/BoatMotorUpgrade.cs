using UnityEngine;

[CreateAssetMenu(fileName = "NewBoatUpgrade", menuName = "Custom/BoatMotorUpgrade")]
public class BoatMotorUpgrade : BaseUpgrade
{
    public float bonusSpeed;
    public float bonusTorque;
    public float bonusAcceleration;
    public float bonusSideDrag;

    public override SavableConfig ApplyUpgrade(BoatFitter fitter)
    {
        BoatMotorConfig motorConfig = fitter.Motor;
        motorConfig.BonusSpeed += bonusSpeed;
        motorConfig.BonusTorque += bonusTorque;
        motorConfig.BonusAcceleration += bonusAcceleration;
        motorConfig.BonusSideDrag += bonusSideDrag;

        return motorConfig;
    }
}
