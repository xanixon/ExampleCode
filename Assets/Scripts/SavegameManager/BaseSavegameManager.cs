using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class BaseSavegameManager : MonoBehaviour
{
    public abstract bool HasSavedProgress { get; }
    public virtual string SavefilePath  {  get { return Application.persistentDataPath + "/" + _savefileName; } }
    [SerializeField] protected string _savefileName = "Savegame.txt";

    public abstract void SaveGame();
    public abstract void LoadGame();
    public abstract int GetCurrentLevelIndex();
    public abstract void SetLevelsProgress(int levelIndex);


    protected virtual void saveFile(string path, string data)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(data);
        }
    }
    protected virtual string loadFile(string path)
    {
        string result;
        using (StreamReader sr = new StreamReader(path))
        {
            result = sr.ReadToEnd();
        }
        return result;
    }
}
