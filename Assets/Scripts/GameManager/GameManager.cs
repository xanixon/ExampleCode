using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private WorldMotor _motor;

    [Inject]
    public void Construct(WorldMotor motor,
                          [Inject(Id = "DecorationsSpawner")] SceneObjectsSpawner decorations,
                          [Inject(Id = "WaterSpawner")] SceneObjectsSpawner water)
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
        
    }
}
