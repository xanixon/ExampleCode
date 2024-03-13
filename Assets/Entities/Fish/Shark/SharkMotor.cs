using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMotor : BaseMotor
{
    public override void AddThrust(float value)
    {
        thrustDirection = value;
    }

    public override void AddTorque(float value)
    {
        torqueDirection = value;
    }   
}
