using System;
using UnityEngine;

[System.Serializable]
public class KeyBinding
{
    [SerializeField] protected KeyCode keyCode = KeyCode.None;

    public KeyBinding() { }
    public KeyBinding(KeyCode keyCode)
    {
        this.keyCode = keyCode;
    }

    public virtual bool CheckHold()
    {
        if (keyCode == KeyCode.None) return false;

        return Input.GetKey(keyCode);
    }

    public virtual bool CheckHit()
    {
        if (keyCode == KeyCode.None) return false;

        return Input.GetKeyDown(keyCode);
    }

    public virtual bool CheckRelease()
    {
        if (keyCode == KeyCode.None) return false;

        return Input.GetKeyUp(keyCode);
    }

    public virtual float GetFloat()
    {
        throw new NotImplementedException();
    }

    public virtual float GetVector2()
    {
        throw new NotImplementedException();
    }
    public enum BindingType
    {
        Hold = 0,
        Hit = 1,
        Release = 2,
        Axis = 3
    }
}
