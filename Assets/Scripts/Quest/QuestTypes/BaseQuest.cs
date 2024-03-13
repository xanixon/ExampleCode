using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public abstract class BaseQuest: ICheated 
{
    public Action<BaseQuest> OnWin,
                             OnLoose,
                             OnUpdateProgress; 
    public float ProgressValueForInspector;
    public float Progress {

        get { return _progress; }
        protected set
        {
            if(_progress >= 0 && _progress < maxProgress)
            {
                _progress = value;
                ProgressValueForInspector = value;
                OnUpdateProgress?.Invoke(this);
                if (_progress >= maxProgress) OnWin?.Invoke(this);
                else if (_progress < 0) OnLoose?.Invoke(this);
            }           
        }
    }
    public int maxProgress
    {
        get { return _maxProgress; }
        protected set
        {
            _maxProgress = value;
        }
    }
    public int MoneyReward;
    public string TaskText;
    private float _progress;
    private int _maxProgress;

    public abstract string GetProgressText();

    public virtual void Init() { }

    protected virtual void AddProgress(float value)
    {
        if (value <= 0) return;
        float integerValue = (float)value;
        Progress += integerValue;
    }

    public void Cheat()
    {
        AddProgress(1);
    }
}
