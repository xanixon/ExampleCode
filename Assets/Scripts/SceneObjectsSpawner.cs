using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneObjectsSpawner : MonoBehaviour
{    
    [SerializeField] protected List<SceneObjectsTemplate> sceneObjectTemplates = new List<SceneObjectsTemplate>();
    [SerializeField] protected float spawnInterval = 1;
    protected float lastSpawnTime = 0;
    protected float totalWeight = 0;
    protected abstract void spawnDecorations();
}
