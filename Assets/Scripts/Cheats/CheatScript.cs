using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class CheatScript : MonoBehaviour
{
    private ICheated _questHolder;
    private ICheated _money;
    [Inject]
    public void Costruct(QuestHolder holder, PlayerMoney money)
    {
        _questHolder = holder;
        _money = money;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            _questHolder.Cheat();
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            _money.Cheat();
        }
    }
}
