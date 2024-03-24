using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaterSpawner : SceneObjectsSpawner
{
   
    [SerializeField] private Vector3[] SpawnPositions;
    private WorldMotor _motor;
    [Inject]
    public void Construct(WorldMotor motor)
    {
        _motor = motor;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnDecorations();
    }
    protected override void spawnDecorations()
    {
        if (!_motor.isRunning || Time.time < lastSpawnTime + spawnInterval) return;
        lastSpawnTime = Time.time;
        GameObject waterDrop = Instantiate(sceneObjectTemplates[0].Prefab, transform);
        int positionIndex = Random.Range(0, SpawnPositions.Length);
        waterDrop.transform.position = SpawnPositions[positionIndex];
        _motor.AddSceneObject(waterDrop.transform);       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        foreach (Vector3 spawnPositions in SpawnPositions)
        {
            Gizmos.DrawWireSphere(spawnPositions, 0.2f);
        }
    }
}
