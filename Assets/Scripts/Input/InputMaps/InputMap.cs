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
        //TODO: когданибудь стоит сделать конфиг инпута
        ChangeLine = new AxisImpulseKeyBinding("Horizontal");
        Jump = new KeyBinding(KeyCode.Space);
        Pause = new KeyBinding(KeyCode.Escape);
    }
}
