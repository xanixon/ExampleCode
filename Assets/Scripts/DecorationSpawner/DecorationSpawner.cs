using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DecorationSpawner : SceneObjectsSpawner
{
    private void Start()
    {
        foreach (var decoration in sceneObjectTemplates)
        {
            totalWeight += decoration.Weight;
        }
    }

    protected override void spawnSceneObject()
    {           
        spawnDecorationInPoint(spawnPositions[0]);
        spawnDecorationInPoint(spawnPositions[1]);
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
                motor.AddSceneObject(newDecorationObject.transform);
                spawnInterval = decoration.Width / Mathf.Abs(motor.Speed);
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Vector3 spawnPositions in spawnPositions)
        {
            Gizmos.DrawWireSphere(spawnPositions, 0.2f);
        }
    }

}
