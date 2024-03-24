using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWorldMotor : WorldMotor
{
    [SerializeField] private float _destructionLinePosition = -10;
    [SerializeField] private Vector3[] SpawnPositions;
    [SerializeField] private Material _floorMat;
    [SerializeField] private Material _wallMat;
    private float _totalWeight = 0;
    private Vector2 _textureOffset = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        foreach (var decoration in decorationTemplates)
        {
            _totalWeight += decoration.Weight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnDecorations();        
        destroyOldDecorations();
        updateDecorationPositons(speed);
    }
    protected override void destroyOldDecorations()
    {
        for (int i = decorationsOnScene.Count - 1;  i >= 0; i--)
        {
            if (decorationsOnScene[i].position.z < _destructionLinePosition)
            {                
                Destroy(decorationsOnScene[i].gameObject);               
                decorationsOnScene.RemoveAt(i);
            }
        }
    }

    protected override void spawnDecorations()
    {
        if (Time.time < lastSpawnTime + spawnInterval) return;

        lastSpawnTime = Time.time;
        float chance = Random.Range(0, _totalWeight);
        float weight = 0;
        foreach (var decoration in decorationTemplates)
        {
            weight += decoration.Weight;
            if (chance < weight)
            {
                GameObject newDecorationObject = Instantiate(decoration.Prefab, transform);
                int positionIndex = Random.Range(0, SpawnPositions.Length);
                newDecorationObject.transform.position = SpawnPositions[positionIndex];
                newDecorationObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                decorationsOnScene.Add(newDecorationObject.transform);
            }
            break;
        }
    }

    protected override void updateDecorationPositons(float speed)
    {
        float offsetSpeed = speed * Time.deltaTime;
        _textureOffset.y += offsetSpeed;
        _floorMat.SetTextureOffset("_MainTex", _textureOffset);
        _wallMat.SetTextureOffset("_MainTex", _textureOffset);

        Vector3 movementVector = new Vector3(0, 0, speed * Time.deltaTime);       
        foreach (Transform decoration in decorationsOnScene)
        {
            decoration.Translate(movementVector, Space.World);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 lineFrom = new Vector3(-20, 0, _destructionLinePosition);
        Vector3 lineTo = new Vector3(20, 0, _destructionLinePosition);
        Gizmos.DrawLine(lineFrom, lineTo);
        foreach(Vector3 spawnPositions in SpawnPositions)
        {
            Gizmos.DrawWireSphere(spawnPositions, 0.2f);
        }
        
    }
}
