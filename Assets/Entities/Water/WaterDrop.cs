using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private AudioSource _source;
    [SerializeField]
    private float _minPitch = 0.9f,
                  _maxPitch = 1.1f;

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        _deathEffect.gameObject.SetActive(true);
        _deathEffect.transform.SetParent(null);
        _deathEffect.transform.localScale = new Vector3(1, 1, 1);
        _source.enabled = true;
        _source.pitch = Random.Range(_minPitch, _maxPitch);
        _source.Play();
        Destroy(_deathEffect, 2);
    }
}
