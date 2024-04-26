using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Zenject;

public abstract class SceneObjectsSpawner : MonoBehaviour
{
    [SerializeField] protected Vector3[] spawnPositions;
    [SerializeField] protected List<SceneObjectsTemplate> sceneObjectTemplates = new List<SceneObjectsTemplate>();
    [SerializeField] protected float spawnInterval = 1;
    protected float lastSpawnTime = 0;
    protected float totalWeight = 0;

    protected WorldMotor motor;
    [Inject]
    public void Construct(WorldMotor motor)
    {
        this.motor = motor;
    }

    protected virtual void Awake()
    {
        foreach (var decoration in sceneObjectTemplates)
        {
            totalWeight += decoration.Weight;
        }
    }

    public SceneObjectsTemplate GetObjectToSpawn()
    {
        float chance = Random.Range(0, totalWeight);
        float weight = 0;
        foreach (var decoration in sceneObjectTemplates)
        {
            weight += decoration.Weight;
            if (chance < weight)
            {
                return decoration;
            }
        }
        return null;
    }
    protected virtual void Update()
    {
        if (motor.isRunning)
            if (Time.time > lastSpawnTime + spawnInterval)
            {
                lastSpawnTime = Time.time;
                spawnSceneObject();
            }
        
    }
    protected abstract void spawnSceneObject();
}
