using System;
using UnityEngine;

[System.Serializable]
public class InputMap
{
    public KeyBinding ChangeLine;
    public KeyBinding Jump;
    public KeyBinding Pause;

    public InputMap(string pathToConfig)
    {
        //TODO: ����������� ����� ������� ������ ������
        ChangeLine = new AxisImpulseKeyBinding("Horizontal");
        Jump = new KeyBinding(KeyCode.Space);
        Pause = new KeyBinding(KeyCode.Escape);
    }
}
