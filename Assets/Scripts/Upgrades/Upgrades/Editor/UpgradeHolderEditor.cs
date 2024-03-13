using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UpgradeHolder), true)]
public class UpgradeHolderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UpgradeHolder upgradeHolder = (UpgradeHolder)target;
        if (GUILayout.Button("Generate ID")) 
        {
            upgradeHolder.GenerateUpgradesID();
        }
    }
}
