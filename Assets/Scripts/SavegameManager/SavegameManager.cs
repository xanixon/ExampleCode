using System.IO;
using UnityEngine;
using Zenject;

public class SavegameManager : BaseSavegameManager
{ 
    public override bool HasSavedProgress
    {
        get
        {
            if (File.Exists(SavefilePath))
                return true;
            else
                return false;
        }
    }
    public string DefaultSavefilePath  { get { return Application.dataPath + "/" + _defaultSaveFileName; } }
    [SerializeField] private bool _loadGameAtStart = true;    
    [SerializeField] private string _defaultSaveFileName = "DefaultSaveFile.txt";
    private BoatFitter _fitter;
    private UpgradesHandler _upgradeHandler;
    private PlayerMoney _money;
    private int _maxReachedLevelIndex = -1;

    [Inject]
    public void Construct(PlayerHealth player, UpgradesHandler upgrade, PlayerMoney money)
    {
        _fitter = player.GetComponent<BoatFitter>();
        _upgradeHandler = upgrade;
        _upgradeHandler.Fitter = _fitter;
        _upgradeHandler.OnUpgradePurchased += SaveGame;
        _money = money;
        if (_loadGameAtStart) LoadGame();
    }
    #region SaveGame
    public override void SaveGame()
    {
        Debug.Log("Сохраняем игру");
        SaveData savedata = collectData();
        string path = SavefilePath;
        string resultJson = JsonUtility.ToJson(savedata);
        saveFile(path, resultJson);
        Debug.Log($"Игра сохранена {path}");

    }
    public void CreateDefaultSavefile()
    {
        Debug.Log("Создаем стартовое сохранение");
        SaveData savedata = collectData();
        string path = DefaultSavefilePath;
        string resultJson = JsonUtility.ToJson(savedata, true);
        saveFile(path, resultJson);
        Debug.Log($"Стартовое сохранение создано {path}");
    }

    public override void SetLevelsProgress(int levelIndex)
    {
        if (_maxReachedLevelIndex < levelIndex)
            _maxReachedLevelIndex = levelIndex;
    }


    private SaveData collectData()
    {
        SaveData result;
        string fitterData = _upgradeHandler.GetSaveData();
        string moneyData = _money.GetSaveData();
        result = new SaveData(fitterData, moneyData, _maxReachedLevelIndex);
        return result;
    }
    #endregion
    #region LoadGame
    public override void LoadGame()
    {
        string path = SavefilePath;
        Debug.Log($"Загружаем сохранение {path}");
        bool isPresent = File.Exists(path);
        if (!isPresent)
        {
            Debug.Log($"Нет активного сохранения, загружаем стартовое сохранение");
            LoadDefaultSavegame();
            return;
        }
        string fileString = loadFile(path);
        SaveData savedata = JsonUtility.FromJson<SaveData>(fileString);
        _maxReachedLevelIndex = savedata.LevelIndex;
        setData(savedata);
        Debug.Log($"Загружено");
    }

    public void LoadDefaultSavegame()
    {
        string path = DefaultSavefilePath;
        bool isPresent = File.Exists(path);
        if (!isPresent)
        {
            Debug.Log($"Файл старого сохранения не обнаружен {path}");
            Debug.Log($"Возможно, стоит создать его через SaveGameManagerEditor -> Set current as default savefile");
            return;
        }
        Debug.Log($"Загружаемся из старого сохранения {path}");
        string fileString = loadFile(path);
        SaveData savedata = JsonUtility.FromJson<SaveData>(fileString);        
        setData(savedata);
        Debug.Log($"Загружено");
    }

    public void ClearSaveFile()
    {
        string path = SavefilePath;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public override int GetCurrentLevelIndex()
    {
        string path = SavefilePath;
        if (File.Exists(path))
        {
            string fileString = loadFile(path);
            SaveData savedata = JsonUtility.FromJson<SaveData>(fileString);
            if (savedata.LevelIndex < 0) Debug.LogError("Сохраненный индекс последнего уровня должен быть положителеным!");
            int result = savedata.LevelIndex;
            return result;
        }
        return 0;
    }

    private void setData(SaveData savedata)
    {
        _upgradeHandler.SetSaveData(savedata.Upgrades);
        _money.SetSaveData(savedata.Money);
    }
    #endregion

    protected struct SaveData
    {
        public string Upgrades;
        public string Money;
        public int LevelIndex;
        public SaveData(string upgrades, string money, int level)
        {
            Upgrades = upgrades;
            Money = money;
            LevelIndex = level;
        }
    }
}
