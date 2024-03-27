using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisImpulseKeyBinding : AxisKeyBinding
{
    private bool readyToReturn = false;
    public AxisImpulseKeyBinding(string axisName) : base(axisName)
    {
    }

    public override float GetFloat()
    {
        float result = Input.GetAxis(axisName);
        if (readyToReturn && Mathf.Abs(result) == 1)
        {
            readyToReturn = false;
            return result;
        }
        else if(result == 0) 
        {
            readyToReturn = true;
        }
        return 0;
        
    }
}
