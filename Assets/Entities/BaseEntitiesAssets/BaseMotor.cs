using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseMotor : MonoBehaviour
{
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float acceleration;
    [SerializeField] protected float torque;
    [Range(0, 1f)]
    [SerializeField] protected float sideDrag = 0.8f;

    protected float thrustDirection;
    protected float torqueDirection;
    protected Rigidbody rb;
    protected Transform tr;
    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = transform;
    }

    protected virtual void FixedUpdate()
    {
        handleMovement();
    }

    public abstract void AddThrust(float value);
    public abstract void AddTorque(float value);

    protected virtual void handleMovement()
    {
        thrustDirection = Mathf.Clamp(thrustDirection, -1, 1);
        torqueDirection = Mathf.Clamp(torqueDirection, -1, 1);
        rb.AddForce(tr.forward * thrustDirection * acceleration);
        rb.AddTorque(transform.up * torqueDirection * torque);

        Vector3 velocity = rb.velocity;
        handleMaxSpeed(velocity);
        handleLateralSpeed(velocity);


        thrustDirection = 0;
        torqueDirection = 0;
    }

    protected virtual void handleMaxSpeed(Vector3 velocity)
    {
        Vector3 velocityNormalized = velocity.normalized;
        if (velocity.magnitude > maxSpeed)
        {
            rb.velocity = velocityNormalized * maxSpeed;
        }
    }

    private void handleLateralSpeed(Vector3 velocity)
    {
        Vector3 sideVelocity = Vector3.Project(velocity, tr.right);
        rb.velocity -= sideVelocity * sideDrag * Time.fixedDeltaTime;
    }
}
