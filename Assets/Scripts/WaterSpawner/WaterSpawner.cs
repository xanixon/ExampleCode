using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaterSpawner : SceneObjectsSpawner
{
    protected override void spawnSceneObject()
    {
        GameObject waterDrop = Instantiate(sceneObjectTemplates[0].Prefab, transform);
        int positionIndex = Random.Range(0, spawnPositions.Length);
        waterDrop.transform.position = spawnPositions[positionIndex];
        motor.AddSceneObject(waterDrop.transform);       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        foreach (Vector3 spawnPositions in spawnPositions)
        {
            Gizmos.DrawWireSphere(spawnPositions, 0.2f);
        }
    }
}
