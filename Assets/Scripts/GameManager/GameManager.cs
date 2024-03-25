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
                          [Inject(Id = "WaterSpawner")] SceneObjectsSpawner water,
                          CameraController camera,
                          [Inject(Id = "Vobla")] GameObject vobla)
    {        
        _motor = motor;
    }
    
}
