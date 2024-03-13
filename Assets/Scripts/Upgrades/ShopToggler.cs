using UnityEngine;
using Zenject;

public class ShopToggler : MonoBehaviour
{
    private GameObject _shop;
    [Inject]
    public void Construct(UpgradeShop shop)
    {
        _shop = shop.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        toggleShop(true);
    }

    private void OnTriggerExit(Collider other)
    {
        toggleShop(false);
    }

    private void toggleShop(bool flag)
    {
        _shop.SetActive(flag);
    }
}
