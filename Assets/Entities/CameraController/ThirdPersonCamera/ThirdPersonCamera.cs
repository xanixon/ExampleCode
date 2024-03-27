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
    
    private Transform _tr;
    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_useFixedUpdate) trackTarget(Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (!_useFixedUpdate) trackTarget(Time.deltaTime);
    }

    private void trackTarget(float deltaTime)
    {
        if (target == null) return;

        Vector3 targetCameraPos;
        Vector3 resultOffset = getCameraOffset(target);
        targetCameraPos = target.position + resultOffset;

        _tr.position = Vector3.Lerp(_tr.position, targetCameraPos, _smoothness * deltaTime);
        if (_lookAt)
        {
            Transform lookAtTarget;
            if (pointToLookAt) lookAtTarget = pointToLookAt;
            else lookAtTarget = target;
            Vector3 dirToTarget = lookAtTarget.position - _tr.position;
            Quaternion targetRotation = Quaternion.LookRotation(dirToTarget);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _smoothness * deltaTime);
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

