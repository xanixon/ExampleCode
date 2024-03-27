using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWorldMotor : WorldMotor
{
    [SerializeField] private float _destructionLinePosition = -10;

    [SerializeField] private Material _floorMat;
    [SerializeField] private Material _wallMat;

    private Vector2 _textureOffset = new Vector2(0, 0);

    // Update is called once per frame
    void Update()
    {
        if (!isRunning) return;
        destroyOldObjects();
        updateSceneObjectsPositons(speed);
    }


    public override void AddSceneObject(Transform objectToAdd)
    {
        objectsOnScene.Add(objectToAdd);
    }
    protected override void destroyOldObjects()
    {
        for (int i = objectsOnScene.Count - 1;  i >= 0; i--)
        {
            if (objectsOnScene[i] == null) { objectsOnScene.RemoveAt(i); continue; }
            if (objectsOnScene[i].position.z < _destructionLinePosition)
            {                
                Destroy(objectsOnScene[i].gameObject);               
                objectsOnScene.RemoveAt(i);
            }
        }
    }

    protected override void updateSceneObjectsPositons(float speed)
    {
        float offsetSpeed = speed * Time.deltaTime;
        _textureOffset.y += offsetSpeed;
        _floorMat.SetTextureOffset("_MainTex", _textureOffset);
        _wallMat.SetTextureOffset("_MainTex", _textureOffset);

        Vector3 movementVector = new Vector3(0, 0, speed * Time.deltaTime);       
        foreach (Transform decoration in objectsOnScene)
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
        
    }

    public override void CleanUp()
    {
        for (int i = objectsOnScene.Count - 1; i >= 0; i--)
        {
            if (objectsOnScene[i].gameObject != null)
                Destroy(objectsOnScene[i].gameObject);
            objectsOnScene.RemoveAt(i);
        }
    }
}
