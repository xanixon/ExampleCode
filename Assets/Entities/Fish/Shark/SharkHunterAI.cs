using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkHunterAI : SharkAI
{
    [SerializeField] private float aggroRange = 30;
    [SerializeField] private SphereCollider aggroCollider;
    private Transform target;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<SharkMotor>();
        tr = transform;
        aggroCollider.radius = aggroRange;
    }

    // Update is called once per frame
    protected override void Update()
    {
        motor.AddThrust(thrustDirection);
        motor.AddTorque(torqueDirection);

        if (target != null)
            chaseTheTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        target = other.transform;
    }

    private void chaseTheTarget()
    {
        Vector3 nDir = (target.position - tr.position).normalized;
        float dot = Vector3.Dot(nDir, tr.right); 
        torqueDirection = dot > 0 ? 1 : -1; 
        thrustDirection = 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
