using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkFangs : MonoBehaviour
{
    [SerializeField] private float Damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        BaseHealth h = other.GetComponentInParent<BaseHealth>();
        if (h != null)
            h.TakeDamage(Damage);
    }
}
