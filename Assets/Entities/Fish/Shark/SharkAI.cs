using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SharkMotor))]
public class SharkAI : BaseEnemyAI
{
    [Range(-1f,1f)]
    [SerializeField] protected float thrustDirection = 1f;
    [Range(-1f, 1f)]
    [SerializeField] protected float torqueDirection = 5f;
    protected SharkMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<SharkMotor>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        motor.AddThrust(thrustDirection);
        motor.AddTorque(torqueDirection);
    }
}
