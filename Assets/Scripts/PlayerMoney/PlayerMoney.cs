using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour, ISavable, ICheated
{
    public int Money {  get; private set;  }
    public event Action<int> OnMoneyUpdate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddMoney(int value)
    {
        if(value < 0) { Debug.LogError("ƒобавл€ть можно только неотрицательное количество денег!"); return; }
        Debug.Log($"»грок получает {value}$");
        Money += value;
        OnMoneyUpdate?.Invoke(value);
    }

    public bool SpendMoney(int value)
    {
        if(value < 0) { Debug.LogError("ѕотратить можно только неотрицательное количество денег!"); return false; }
        if (value > Money) return false;
        
        Money -= value;
        return true;
    }

    public string GetSaveData()
    {
        PlayerMoneySavedata savedata = new PlayerMoneySavedata(Money);
        string result = JsonUtility.ToJson(savedata);
        return result;
    }

    public void SetSaveData(string jsonSavedata)
    {
        PlayerMoneySavedata savedata = JsonUtility.FromJson<PlayerMoneySavedata>(jsonSavedata);
        Money = savedata.Money;
    }

    public void Cheat()
    {
        int moneyToAdd = 10;
        Debug.Log($"ƒобавл€ю {moneyToAdd} денег");
        Money += moneyToAdd;
    }
}
