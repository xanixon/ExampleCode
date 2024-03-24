using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class VoblaRunAnimation : MonoBehaviour
{
    [SerializeField] private float _minAnimationSpeedAt = 1;
    [SerializeField] private float _maxAnimationSpeedAt = 3;
    [SerializeField] private float _minSpeed = 5;
    [SerializeField] private float _maxSpeed = 10;
    private Animator _anim;
    private WorldMotor _motor;

    [Inject]
    public void Construct(WorldMotor motor)
    {
        _motor = motor;
    }
    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float absSpeed = Mathf.Abs(_motor.Speed);
        float t = Mathf.Clamp((absSpeed - _minAnimationSpeedAt) / (_maxAnimationSpeedAt - _minAnimationSpeedAt), 0, 1);
        float resultSpeed = Mathf.Lerp(_minSpeed, _maxSpeed, t);
        _anim.SetFloat("Speed", resultSpeed);
    }
}
