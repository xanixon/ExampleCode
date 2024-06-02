using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VoblaLineHandler : MonoBehaviour
{
    [SerializeField] protected float lineWidth = 1;
    [SerializeField] protected int lineCount = 3;
    protected int currentLine = 0;

    public abstract void ChangeLine(int direction);
    public abstract void Jump();
    protected abstract void lineControl(int currentLine);
    protected abstract void jumpControl();

    
}