using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(VoblaLineHandler))]
[RequireComponent(typeof(VoblaRunAnimation))]
public class TableVobla : InteractableTableObject
{
    [SerializeField] private Transform _lookAtPoint;
    private Animator _anim;
    private VoblaLineHandler _lineHandler;
    private VoblaRunAnimation _runAnimation;
    private WorldMotor _motor;

    [Inject]
    public void Construct(WorldMotor motor)
    {
        _motor  = motor;
    }
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _lineHandler = GetComponent<VoblaLineHandler>();
        _runAnimation = GetComponent<VoblaRunAnimation>();
    }
    void OnMouseEnter()
    {
        Wiggle();
    }
    public override void Interact()
    {
        _lineHandler.enabled = true;
        _runAnimation.enabled = true;
        _motor.isRunning = true;
        followingCamera.SetTarget(transform);
        followingCamera.SetLookAtPoint(_lookAtPoint); 
        hint.SetHint("");
        Destroy(this);
    }

    public void Wiggle()
    {
        _anim.SetTrigger("Wiggle");
        followingCamera.SetTarget(transform);
    }

}
