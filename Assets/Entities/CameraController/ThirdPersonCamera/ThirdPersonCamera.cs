using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ThirdPersonCamera : CameraController
{
    [SerializeField] private bool _useFixedUpdate = false;
    [SerializeField] private bool lookAt = true;
    [SerializeField] private bool useLocalOffset;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness = 20;
    [SerializeField] private Transform pointToLookAt = null;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
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

        tr.position = Vector3.Lerp(tr.position, targetCameraPos, smoothness * Time.deltaTime);
        if (lookAt)
        {
            Transform lookAtTarget;
            if (pointToLookAt) lookAtTarget = pointToLookAt;
            else lookAtTarget = target;
            tr.LookAt(lookAtTarget);
        }
    }

    private Vector3 getCameraOffset(Transform target)
    {
        Vector3 resultOffset;
        if (useLocalOffset)
        {
            resultOffset = target.forward * offset.z + target.up * offset.y + target.right * offset.x;
        }
        else
        {
            resultOffset = offset;
        }
        return resultOffset;
    }   
}

