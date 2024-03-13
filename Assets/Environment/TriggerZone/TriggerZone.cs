using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public event Action TriggerEnteredHandler;
    [SerializeField] private Collider triggerCollider;
    private void OnTriggerEnter(Collider other)
    {
        TriggerEnteredHandler?.Invoke();
        triggerCollider.enabled = false;
    }
}
