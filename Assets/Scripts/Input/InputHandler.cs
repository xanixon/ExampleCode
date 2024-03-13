using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    public event Action<float> AddThrust;
    public event Action<float> Turn;
    public event Action StartFishing;
    public event Action HookFish;
    public event Action Bonk;
    public event Action Pause;

    [SerializeField] private InputMap currentInputMap;

    [Inject]
    public void Construct(PlayerHealth player, BaseFishingView fishingHandler, PauseHandler pause)
    {
        BaseMotor motor = player.GetComponent<BaseMotor>();
        AddThrust += motor.AddThrust;
        Turn += motor.AddTorque;
        OarHandler oar = player.GetComponentInChildren<OarHandler>();
        Bonk += oar.Attack;
        StartFishing += fishingHandler.OnStartFishing;
        HookFish += fishingHandler.OnHook;
        Pause += pause.TogglePause;
    }

    // Update is called once per frame
    void Update()
    {
        float thrust = currentInputMap.ForwardThrust.GetFloat();
        float torque = currentInputMap.RightTurn.GetFloat();
        if(thrust != 0) AddThrust?.Invoke(thrust);
        if(torque != 0) Turn?.Invoke(torque);
        if (currentInputMap.Bonk.CheckHit()) Bonk?.Invoke();
        if (currentInputMap.HookFish.CheckHit()) HookFish?.Invoke();
        if (currentInputMap.StartFishing.CheckHit()) StartFishing?.Invoke();      
        if (currentInputMap.Pause.CheckHit()) Pause?.Invoke();
    }

    public void SetInputMap(InputMap inputMap)
    {
        currentInputMap = inputMap;
    }
}
