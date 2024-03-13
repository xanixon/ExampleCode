using UnityEditor;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;

[CustomEditor(typeof(SavegameManager))]
public class SavegameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SavegameManager savegameManager = (SavegameManager)target;

        if(GUILayout.Button("Savegame"))
        {
            savegameManager.SaveGame();
        }

        if (GUILayout.Button("Set current as default savefile"))
        {
            savegameManager.CreateDefaultSavefile();
        }


        if (GUILayout.Button("LoadGame"))
        {
            savegameManager.LoadGame();
        }
#if UNITY_EDITOR_WIN

        if(GUILayout.Button("Open savefile folder"))
        {
            string filepath = savegameManager.SavefilePath;
            string pathToFolder = new FileInfo(filepath).Directory.FullName;
            Process.Start("explorer.exe", pathToFolder);
        }
#endif
    }
}
