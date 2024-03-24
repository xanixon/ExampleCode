using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldMotor : MonoBehaviour
{
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float spawnInterval = 1;
    [SerializeField] protected List<DecorationTemplate> decorationTemplates = new List<DecorationTemplate>();
    protected List<Transform> decorationsOnScene = new List<Transform>();
    protected float lastSpawnTime = 0;

    protected abstract void updateDecorationPositons(float speed);
    protected abstract void spawnDecorations();
    protected abstract void destroyOldDecorations();
}
