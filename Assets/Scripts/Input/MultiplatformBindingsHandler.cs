using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplatformBindingsHandler : BindingsHandler
{
    public List<string> PathsToConfig = new List<string>();
    public PlatformType TargetPlatform;


    // Start is called before the first frame update
    protected override void Start()
    {
        handler = GetComponent<InputHandler>();
        InputMap selectedInputMap;
        if (TargetPlatform  == PlatformType.Windows)
        {
            selectedInputMap = new InputMap("");
        }
        else if(TargetPlatform == PlatformType.Android)
        {
            selectedInputMap = new AndroidInputMap("");
        }
        else
        {
            selectedInputMap = new InputMap("");
        }

        handler.SetInputMap(selectedInputMap);
    }

}
