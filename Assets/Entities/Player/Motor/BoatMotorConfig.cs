using System;

[Serializable]
public class BoatMotorConfig: SavableConfig
{
    public float BonusSpeed;
    public float BonusAcceleration;
    public float BonusTorque;
    public float BonusSideDrag;

    public BoatMotorConfig() { }
    public BoatMotorConfig(float speed, float acceleration, float torque, float sideDrag)
    {
        BonusSpeed = speed;
        BonusAcceleration = acceleration;
        BonusTorque = torque;
        BonusSideDrag = sideDrag;
    }
}
