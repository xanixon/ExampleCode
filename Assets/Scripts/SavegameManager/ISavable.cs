using System;
using System.Collections.Generic;
using UnityEngine;

public interface ISavable 
{
    string GetSaveData();
    void SetSaveData(string jsonSavedata);
}
