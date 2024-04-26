using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class FoodOnTable : InteractableTableObject
{
    [SerializeField] private List<GameObject> _food = new List<GameObject>();
    [SerializeField] private AudioSource _beerSound;

    public override void Interact()
    {
        followingCamera.SetTarget(transform);
        if (_food.Count > 0)
        {
            _food[0].SetActive(false);
            _food.Remove(_food[0]);
            _beerSound.Play();
        }        
    }
}
