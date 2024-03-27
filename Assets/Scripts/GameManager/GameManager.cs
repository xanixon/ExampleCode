using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{

    [Inject]
    public void Construct(WorldMotor motor,
                          [Inject(Id = "DecorationsSpawner")] SceneObjectsSpawner decorations,
                          [Inject(Id = "WaterSpawner")] SceneObjectsSpawner water,
                          [Inject(Id = "ObstacleSpawner")] SceneObjectsSpawner obstacles,
                          CameraController camera,
                          [Inject(Id = "Vobla")] GameObject vobla,
                          GameOverHandler gameOver,
                          PauseHandler pause)
    {        
        
    }
    
}
