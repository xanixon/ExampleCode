using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidInputMap : InputMap
{
    public AndroidInputMap(string pathToConfig) : base(pathToConfig)
    {
        ChangeLine = new AndroidSwipeKeyBinding();
        Jump = new AndroidScreenTapKeyBinding();
        Pause = new KeyBinding(KeyCode.None);
    }
}
