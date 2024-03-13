using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ScoredWinScreen : WinScreen
{
    [SerializeField] private TMP_Text _winStatsText;
    private FishingCollector _fishing;
    private KillsCollector _kills;

    [Inject]
    public void Construct(FishingCollector fishing, KillsCollector kills)
    {
        this._fishing = fishing;
        this._kills = kills;
    }

    public override void SetUp(string nextLevelName, string winMessage, int moneyReward)
    {
        this.nextLevelName = nextLevelName;
        winText.text = winMessage;
        if(moneyReward > 0)
           rewardText.text = $"+{moneyReward}$";
        _winStatsText.text = _fishing.ToString()
                          +
                          "\n" +
                          _kills.ToString();
    }
}
