using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkHealth : BaseHealth
{
    [SerializeField] private ParticleSystem deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        SetUp(1);
        DeathEvent += deathHandler;
    }

    private void deathHandler(BaseHealth health)
    {
        Transform ps = deathEffect.transform;
        ps.parent = null;
        ps.localScale = Vector3.one;
        deathEffect.Play();
        Destroy(deathEffect.gameObject, 5);

        Destroy(gameObject);       
    }
}
