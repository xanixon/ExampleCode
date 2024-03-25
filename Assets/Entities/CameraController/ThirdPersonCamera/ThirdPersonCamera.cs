using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ThirdPersonCamera : CameraController
{
    [SerializeField] private bool _useFixedUpdate = false;    
    [SerializeField] private bool _useLocalOffset;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothness = 20;
    [SerializeField] private Transform _pointToLookAt = null;
    private Transform _tr;
    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_useFixedUpdate) trackTarget();
    }

    private void Update()
    {
        if (!_useFixedUpdate) trackTarget();
    }

    private void trackTarget()
    {
        if (target == null) return;

        Vector3 targetCameraPos;
        Vector3 resultOffset = getCameraOffset(target);
        targetCameraPos = target.position + resultOffset;

        _tr.position = Vector3.Lerp(_tr.position, targetCameraPos, _smoothness * Time.deltaTime);
        if (_lookAt)
        {
            Transform lookAtTarget;
            if (_pointToLookAt) lookAtTarget = _pointToLookAt;
            else lookAtTarget = target;
            _tr.LookAt(lookAtTarget);
        }
    }

    private Vector3 getCameraOffset(Transform target)
    {
        Vector3 resultOffset;
        if (_useLocalOffset)
        {
            resultOffset = target.forward * _offset.z + target.up * _offset.y + target.right * _offset.x;
        }
        else
        {
            resultOffset = _offset;
        }
        return resultOffset;
    }   
}

