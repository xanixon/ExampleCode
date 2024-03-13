using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OarHandler : MonoBehaviour, IUpgradable
{
    public bool OarPurchased
    {
        get
        {
            return _oarPurchased;
        }
        private set
        {
            OarObject.SetActive(value);
            _oarPurchased = value;
        }
    }

    public float Damage
    {
        get { return _baseDamage + _bonusDamage; }
    }
    public float SplashRadius
    {
        get { return _baseSplashRadius + _bonusRadius; }

    }
    [SerializeField] private GameObject _splashPrefab;
    [SerializeField] private SphereCollider _hitCollider;
    [SerializeField] private GameObject OarObject;
    [SerializeField] private float _baseDamage;
    [SerializeField] private float _baseSplashRadius;
    private OarConfig _config;

    private float _bonusDamage;
    private float _bonusRadius;
    private bool _oarPurchased;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Attack()
    {
        if (OarPurchased)
            anim.SetTrigger("Bonk");
    }
    public void EnableHitCollider()
    {
        _hitCollider.radius = SplashRadius;
        _hitCollider.enabled = true;
    }

    public void DisbleHitCollider()
    {
        _hitCollider.enabled = false;
        GameObject splash = Instantiate(_splashPrefab, _hitCollider.transform.position, Quaternion.identity);
        splash.transform.localScale *= 1 + 5 * _bonusRadius;
        Destroy(splash, 3);
    }

    public void Init()  { }

    public void RecalculateStats() 
    {
        OarPurchased = _config.OarPurchased;
        _bonusDamage = _config.BonusDamage;
        _bonusRadius = _config.BonusRadius;
    }

    public void SetConfig(SavableConfig newConfig)
    {
        _config = (OarConfig)newConfig;
        RecalculateStats();
    }

}
