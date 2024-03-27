using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BrokenBeerMug : MonoBehaviour
{
    [SerializeField] private Animation _anim;
    [SerializeField] private GameObject _mug;
    [SerializeField] private AudioSource _source;

    public void PlayHitSound()
    {
        _source.Play(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        _anim.Play();
        _mug.SetActive(true);
    }

    public class Factory : PlaceholderFactory<BrokenBeerMug> { }
}
