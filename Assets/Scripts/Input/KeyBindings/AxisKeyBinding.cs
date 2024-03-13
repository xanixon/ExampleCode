using UnityEngine;

[System.Serializable]
public class AxisKeyBinding : KeyBinding
{
    [SerializeField] private string axisName;
    public AxisKeyBinding(string axisName)
    {
        this.axisName = axisName;
    }

    public override float GetFloat()
    {
        return Input.GetAxis(axisName);
    }
}
