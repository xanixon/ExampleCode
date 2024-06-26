using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstaclesSpawner : SceneObjectsSpawner
{
    [SerializeField] private float _maxSpawnInterval = 3;
    protected override void spawnSceneObject()
    {
        SceneObjectsTemplate selectedTemplate = GetObjectToSpawn();
        GameObject obstacle = Instantiate(selectedTemplate.Prefab, transform);
        int positionIndex = Random.Range(0, spawnPositions.Length);
        obstacle.transform.position = spawnPositions[positionIndex];
        motor.AddSceneObject(obstacle.transform);
        float minSpawnInterval = selectedTemplate.Width / Mathf.Abs(motor.Speed);
        spawnInterval = Random.Range(minSpawnInterval, _maxSpawnInterval);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Vector3 spawnPositions in spawnPositions)
        {
            Gizmos.DrawWireSphere(spawnPositions, 0.1f);
        }
    }
}
