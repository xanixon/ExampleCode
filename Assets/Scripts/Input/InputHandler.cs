using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    public event Action<int> ChangeLine;
    public event Action Jump;
    public event Action Pause;

    [SerializeField] private InputMap currentInputMap;

    [Inject]
    public void Construct([Inject(Id = "Vobla")] GameObject player, PauseHandler pause)
    {       
        Pause += pause.TogglePause;
        VoblaLineHandler lineHandler = player.GetComponent<VoblaLineHandler>();
        ChangeLine += lineHandler.ChangeLine;
        Jump += lineHandler.Jump;
    }

    // Update is called once per frame
    void Update()
    {     
        if (currentInputMap.Pause.CheckHit()) Pause?.Invoke();
        if(currentInputMap.Jump.CheckHit()) Jump?.Invoke();
        float lineChange = currentInputMap.ChangeLine.GetFloat();
        Debug.Log(lineChange);
        if (lineChange != 0)
            ChangeLine((int)lineChange);
    }

    public void SetInputMap(InputMap inputMap)
    {
        currentInputMap = inputMap;
    }
}
