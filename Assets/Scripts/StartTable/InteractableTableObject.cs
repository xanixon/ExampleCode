using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class InteractableTableObject : MonoBehaviour
{
    public string HintText;
    public abstract void Interact();
    public abstract void Wiggle();

    protected BaseUIHint hint;

    [Inject]
    public void Construct(BaseUIHint hint)
    {
        this.hint = hint;
    }
    protected virtual void OnMouseEnter()
    {
        hint.SetHint(HintText);
        Wiggle();
    }

    protected virtual void OnMouseDown()
    {
        Interact();
    }

    private void OnMouseExit()
    {
        hint.SetHint("");
    }
}
