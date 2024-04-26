using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class InteractableTableObject : MonoBehaviour
{
    public string HintText;
    public float CameraReturnDelay = 2;
    protected CameraController followingCamera;
    protected BaseUIHint hint;
    public abstract void Interact();

    [Inject]
    public void Construct(BaseUIHint hint, CameraController camera)
    {
        this.hint = hint;
        followingCamera = camera;
    }

    protected virtual void OnMouseDown()
    {
        hint.SetHint(HintText);
        Interact();
    }

    protected virtual void OnDestroy()
    {
        StopAllCoroutines();
    }
}
