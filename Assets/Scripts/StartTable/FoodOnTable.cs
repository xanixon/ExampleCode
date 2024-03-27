using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class FoodOnTable : InteractableTableObject
{
    [SerializeField] private List<GameObject> _food = new List<GameObject>();
    [SerializeField] private AudioSource _beerSound;
    private CameraController _camera;

    [Inject]
    public void Construct(CameraController camera)
    {
        
        _camera = camera;
    }

    public override void Interact()
    {
        if( _food.Count > 0 )
        {
            _food[0].SetActive(false);
            _food.Remove(_food[0]);
            _beerSound.Play();
        }        
    }

    public override void Wiggle()
    {
        _camera.SetTarget(transform);
    }

}
