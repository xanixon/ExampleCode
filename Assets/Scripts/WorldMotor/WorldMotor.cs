using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldMotor : MonoBehaviour
{
    public bool isRunning = true;
    public float Speed { get { return speed; } }
    [SerializeField] protected float speed = 1;
    protected List<Transform> objectsOnScene = new List<Transform>();    

    public abstract void AddSceneObject(Transform objectToAdd);
    public abstract void CleanUp();
    protected abstract void updateSceneObjectsPositons(float speed);
    protected abstract void destroyOldObjects();
}
