using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable 
{
    void Init();
    void RecalculateStats();
    void SetConfig(SavableConfig newConfig);
}
