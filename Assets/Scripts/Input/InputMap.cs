using UnityEngine;

[System.Serializable]
public class InputMap
{
    public KeyBinding ForwardThrust;
    public KeyBinding BackThrust;
    public KeyBinding LeftTurn;
    public KeyBinding RightTurn;
    public KeyBinding StartFishing;
    public KeyBinding HookFish;
    public KeyBinding Bonk;
    public KeyBinding Pause;

    public InputMap(string pathToConfig)
    {
        //TODO: когданибудь стоит сделать конфиг инпута
        ForwardThrust = new AxisKeyBinding("Vertical"); 
        BackThrust = new KeyBinding(KeyCode.None);
        LeftTurn = new KeyBinding(KeyCode.A);
        RightTurn = new AxisKeyBinding("Horizontal");
        StartFishing = new KeyBinding(KeyCode.Space);
        HookFish = new KeyBinding(KeyCode.Space);
        Bonk = new KeyBinding(KeyCode.C);
        Pause = new KeyBinding(KeyCode.Escape);
    }
}
