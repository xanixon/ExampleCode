using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SequentalMarker : BaseCompassMarker
{
    [SerializeField] private GameObject _nextMarker;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(_nextMarker != null)
           _nextMarker.SetActive(true);
    }
}
