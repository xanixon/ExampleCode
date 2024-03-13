using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UpgradesHandler : MonoBehaviour, ISavable
{
    public BoatFitter Fitter;
    public event Action OnUpgradePurchased;
    [SerializeField] private UpgradeHolder _upgrades;
    [SerializeField] private List<BaseUpgrade> _appliedUpgrades = new List<BaseUpgrade>();
    private PlayerMoney _playerMoney;

    [Inject]
    public void Construct(PlayerMoney playerMoney)
    {
        _playerMoney = playerMoney;
    }
    public List<BaseUpgrade> GetAvailableUpgrades()
    {
        List<BaseUpgrade> result = _upgrades.GetUpgradeList();
        foreach (BaseUpgrade upgrade in _appliedUpgrades)
        {
            BaseUpgrade appliedUpgrade = result.Find(x => x == upgrade);
            result.Remove(appliedUpgrade);
        }
        return result;
    }
    public void PurchaseUpgrade(int id)
    {
        List<BaseUpgrade> upgrade = GetUpgradesByIds(new int[] {id});        
        if(upgrade.Count == 0) { Debug.LogError($"Не удалось найти улучшение с ID = {id}"); return; }        
        addUpgrades(upgrade);
    }
    
    public void RemoveUpgrade(int id)
    {
        BaseUpgrade upgrade = _appliedUpgrades.Find(x => x.Id == id);
        if (upgrade == null) { Debug.LogError($"Не удалось найти примененное улучшение с ID = {id}"); return; }
        _appliedUpgrades.Remove(upgrade);
    }
    public List<BaseUpgrade> GetUpgradesByIds(int[] upgradesId)
    {
        List <BaseUpgrade> result = new List <BaseUpgrade>();
        foreach(int id in upgradesId)
        {
            BaseUpgrade upgrade = _upgrades.FindUpgrade(id);
            if(upgrade != null) 
               result.Add(upgrade);
        }
        return result;
    }

    public string GetSaveData()
    {
        int[] upgradesID = new int[_appliedUpgrades.Count];
        UpgradesSavedata savedata = new UpgradesSavedata(upgradesID);
        for (int i = 0; i < _appliedUpgrades.Count; i++)
        {
            savedata.AppliedUpgrades[i] = _appliedUpgrades[i].Id;
        }

        string result = JsonUtility.ToJson(savedata);
        return result;
    }

    public void SetSaveData(string jsonSavedata)
    {
        UpgradesSavedata savedata = JsonUtility.FromJson<UpgradesSavedata>(jsonSavedata);
        foreach (int id in savedata.AppliedUpgrades)
        {
            BaseUpgrade upgrade = _upgrades.FindUpgrade(id);
            if (upgrade == null) { Debug.LogError($"Не удалось загрузить улучшение {upgrade.name}"); continue; }
            else _appliedUpgrades.Add(upgrade);
        }
        applyUpgrades();
    }

    protected void addUpgrades(List<BaseUpgrade> newUpgrades)
    {
        foreach (var upgrade in newUpgrades)
        {
            BaseUpgrade oldUpgrades = _appliedUpgrades.Find(x => x == upgrade);
            if (oldUpgrades != null) { Debug.Log("Такое улучшение уже добавлено!"); break; }
            if (_playerMoney.SpendMoney(upgrade.Price))
            {
                Debug.Log($"Куплено улучшение {upgrade.name}");
                _appliedUpgrades.Add(upgrade);
                OnUpgradePurchased?.Invoke();
            }
            else
            { Debug.Log($"Недостаточно денег для покупки улучшения {upgrade.name}"); }
        }
        applyUpgrades();
    }

    protected void applyUpgrades()
    {
        Fitter.ResetUpgrades();
        foreach (var upgrade in _appliedUpgrades)
        {
            upgrade.ApplyUpgrade(Fitter);
        }
        Fitter.ApplyConfigs();
    }
}
