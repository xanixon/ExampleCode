using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DecorationSpawner : SceneObjectsSpawner
{
    [SerializeField] private Vector3[] SpawnPositions;
    private WorldMotor _motor;
    [Inject]
    public void Construct(WorldMotor motor)
    {
        _motor = motor;
    }
    private void Start()
    {
        foreach (var decoration in sceneObjectTemplates)
        {
            totalWeight += decoration.Weight;
        }
    }

    private void Update()
    {
        spawnDecorations();
    }

    protected override void spawnDecorations()
    {
        if (!_motor.isRunning || Time.time < lastSpawnTime + spawnInterval) return;

        lastSpawnTime = Time.time;
        spawnDecorationInPoint(SpawnPositions[0]);
        spawnDecorationInPoint(SpawnPositions[1]);
    }

    private void spawnDecorationInPoint(Vector3 point)
    {
        float chance = Random.Range(0, totalWeight);
        float weight = 0;
        foreach (var decoration in sceneObjectTemplates)
        {
            weight += decoration.Weight;
            if (chance < weight)
            {
                GameObject newDecorationObject = Instantiate(decoration.Prefab, transform);

                newDecorationObject.transform.position = point;
                newDecorationObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                _motor.AddSceneObject(newDecorationObject.transform);
                spawnInterval = decoration.Width / Mathf.Abs(_motor.Speed);
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Vector3 spawnPositions in SpawnPositions)
        {
            Gizmos.DrawWireSphere(spawnPositions, 0.2f);
        }
    }

}
