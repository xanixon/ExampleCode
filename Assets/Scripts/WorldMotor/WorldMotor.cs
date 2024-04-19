using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldMotor : MonoBehaviour
{
    public bool isRunning = true;
    public float Speed { get { return speed; } }
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float minSpeed = 0.5f,
                                     maxSpeed = 2;
    protected List<Transform> objectsOnScene = new List<Transform>();    

    public abstract void AddSceneObject(Transform objectToAdd);
    public virtual void AddSpeed(float value)
    {
        speed += value;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    }
    public abstract void CleanUp();
    protected abstract void updateSceneObjectsPositons(float speed);
    protected abstract void destroyOldObjects();
}
