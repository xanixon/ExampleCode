using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _loreDescription;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    private UpgradeShop _shop;
    private int _upgradeId;

    public void SetUp(BaseUpgrade upgrade, UpgradeShop shop)
    {
        this._shop = shop;
        _title.text = upgrade.UpgradeName;
        _loreDescription.text = upgrade.LoreDescription;
        _icon.sprite = upgrade.Icon;
        _price.text = upgrade.Price.ToString();
        _upgradeId = upgrade.Id;
    }

    public void OnButtonClick()
    {
        _shop.PurchaseUpgrade(_upgradeId);
    }
}
