using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(VoblaLineHandler))]
[RequireComponent(typeof(VoblaRunAnimation))]
public class TableVobla : InteractableTableObject
{
    private Animator _anim;
    private VoblaLineHandler _lineHandler;
    private VoblaRunAnimation _runAnimation;
    private WorldMotor _motor;
    private CameraController _camera;

    [Inject]
    public void Construct(WorldMotor motor,                         
                         CameraController camera)
    {
        _motor  = motor;
        _camera = camera;
    }
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _lineHandler = GetComponent<VoblaLineHandler>();
        _runAnimation = GetComponent<VoblaRunAnimation>();
    }
    public override void Interact()
    {
        _lineHandler.enabled = true;
        _runAnimation.enabled = true;
        _motor.isRunning = true;
        _anim.SetTrigger("Run");
        _camera.SetLookAtFlag(false);
        _camera.SetTarget(transform);
        Destroy(this);
    }

    public override void Wiggle()
    {
        _anim.SetTrigger("Wiggle");
    }

}
