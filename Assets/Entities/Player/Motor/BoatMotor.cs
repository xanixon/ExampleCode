using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMotor : BaseMotor, IUpgradable
{    
    [SerializeField] private Transform _boatHolder;
    [SerializeField] private float _maxRollValue = 15f;
    [SerializeField] private float _maxRollAtTorque = 50f; //максимальное значение крена достигается при этом значении угловой скорости
    [SerializeField] private float _rollSmoothness = 20;

    private bool _wasInitialized = false;
    private float _baseMaxSpeed;
    private float _baseTorque;
    private float _baseAcceleration;
    private float _baseSideDrag;
    private BoatMotorConfig _config;  
    
    protected override void FixedUpdate()
    {
        rollHandler();
        base.FixedUpdate();
    }
    public override void AddThrust(float value)
    {
        thrustDirection = value;
    }
    public override void AddTorque(float value)
    {
        torqueDirection = value;
    }

    public void Init()
    {
        _baseMaxSpeed = maxSpeed;
        _baseTorque = torque;
        _baseAcceleration = acceleration;
        _baseSideDrag = sideDrag;
    }
    public void RecalculateStats()
    {        
        maxSpeed = _baseMaxSpeed + _config.BonusSpeed;
        acceleration = _baseAcceleration + _config.BonusAcceleration;
        torque = _baseTorque + _config.BonusTorque;
        sideDrag = _baseSideDrag + _config.BonusSideDrag;
    }

    public void SetConfig(SavableConfig newConfig)
    {
        if (!_wasInitialized) { Init(); _wasInitialized = true; }

        BoatMotorConfig motorConfig = (BoatMotorConfig)newConfig;       
        _config = motorConfig;
        RecalculateStats();
    }
    protected virtual void rollHandler()
    {
        float currentTorque = rb.angularVelocity.y / Time.fixedDeltaTime;
        float currentRoll = Mathf.Lerp(-_maxRollValue,
                                         _maxRollValue,
                                         0.5f + (currentTorque / 2) / _maxRollAtTorque);

        Vector3 currentEuler = _boatHolder.rotation.eulerAngles;
        Quaternion smoothedRotation = Quaternion.Lerp(_boatHolder.rotation,
                                      Quaternion.Euler(currentEuler.x, currentEuler.y, currentRoll),
                                      _rollSmoothness * Time.fixedDeltaTime);

        _boatHolder.rotation = smoothedRotation;
    }
}
