using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgradeHolder", menuName = "Custom/UpgradeHolder")]
public class UpgradeHolder : ScriptableObject
{
    [SerializeField] private List<BaseUpgrade> _upgradeList = new List<BaseUpgrade>();
    [SerializeField] private int startID = 0;

    public void GenerateUpgradesID()
    {
        int i = startID;
        foreach (BaseUpgrade upgrade in _upgradeList)
        {          
            upgrade.Id = i;
            i++;
        }
    }

    public BaseUpgrade FindUpgrade(int id)
    {
        BaseUpgrade upgrade = _upgradeList.Find(x => x.Id == id);
        if (upgrade == null) { Debug.LogError($"Не удалось найти улучшение с ID {id}"); return null; }
        return upgrade;
    }

    public List<BaseUpgrade> GetUpgradeList()
    {
        List<BaseUpgrade> result = new List<BaseUpgrade>(_upgradeList);
        return result;
    }
}
