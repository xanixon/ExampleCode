using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] private Transform buttonParent;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject NothingToUpgradeLabel;
    [SerializeField] private TMP_Text playerMoney;
    private UpgradesHandler _upgradesHandler;
    private PlayerMoney _money;

    [Inject]
    public void Construct(UpgradesHandler handler, PlayerMoney money)
    {
        _upgradesHandler = handler;
        _money = money;
    }

    private void OnEnable()
    {
        FillUpgradeList();
    }

    public void FillUpgradeList()
    {
        NothingToUpgradeLabel.SetActive(false);
        int childCount = buttonParent.childCount;
        for(int i = 1; i < childCount; i++)
        {
            Destroy(buttonParent.GetChild(i).gameObject);
        }

        playerMoney.text = _money.Money.ToString();

        List<BaseUpgrade> list = _upgradesHandler.GetAvailableUpgrades();
        if (list.Count == 0) 
        {
            NothingToUpgradeLabel.SetActive(true);
            return;
        }
        list.Sort((x, y) => x.Price - y.Price);
        foreach(BaseUpgrade upgrade in list)
        {
            GameObject upgradeButton = Instantiate(buttonPrefab,buttonParent);
            ShopButton shopButton = upgradeButton.GetComponent<ShopButton>();
            shopButton.SetUp(upgrade, this);
            Button uiButton = upgradeButton.GetComponent<Button>();
            uiButton.interactable = upgrade.Price <= _money.Money;          
        }
    }

    public void PurchaseUpgrade(int id)
    {
        _upgradesHandler.PurchaseUpgrade(id);
        FillUpgradeList();
    }
}
