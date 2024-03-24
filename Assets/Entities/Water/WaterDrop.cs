using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffect;

    private void OnDestroy()
    {
        _deathEffect.gameObject.SetActive(true);
        _deathEffect.transform.SetParent(null);
        _deathEffect.transform.localScale = new Vector3(1, 1, 1);
        Destroy(_deathEffect, 2);
    }
}
