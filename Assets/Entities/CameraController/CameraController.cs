using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class CameraController: MonoBehaviour
{
    [SerializeField] protected Transform target;
    public virtual void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}