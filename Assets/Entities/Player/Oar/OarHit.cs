using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarHit : MonoBehaviour
{
    [SerializeField] private OarHandler oar;

    private void OnTriggerEnter(Collider other)
    {
        BaseHealth h = other.GetComponentInParent<BaseHealth>();
        if (h != null)
            h.TakeDamage(oar.Damage);
    }


}
