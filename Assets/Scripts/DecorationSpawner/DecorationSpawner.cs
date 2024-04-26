using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DecorationSpawner : SceneObjectsSpawner
{

    protected override void spawnSceneObject()
    {
        spawnDecorationInPoint(spawnPositions[0]);
        spawnDecorationInPoint(spawnPositions[1]);
    }

    private void spawnDecorationInPoint(Vector3 point)
    {
        SceneObjectsTemplate selectedTemplate = GetObjectToSpawn();
        GameObject newDecorationObject = Instantiate(selectedTemplate.Prefab, transform);

        newDecorationObject.transform.position = point;
        newDecorationObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        motor.AddSceneObject(newDecorationObject.transform);
        spawnInterval = selectedTemplate.Width / Mathf.Abs(motor.Speed);
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
