using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class CameraController: MonoBehaviour
{
    [SerializeField] protected Transform pointToLookAt = null;
    [SerializeField] protected Transform target;
    [SerializeField] protected bool _lookAt = true;
    public virtual void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public virtual void SetLookAtFlag(bool flag)
    {
        _lookAt = flag;
    }
    public virtual void SetLookAtPoint(Transform newLookAtPoint)
    {
        pointToLookAt = newLookAtPoint;
    }
}