using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestLabel : MonoBehaviour
{

    public string LabelText
    {
        set { _questLabel.text = value; }
    }
    public string ProgressText
    {
        set { _questValue.text = value; }
    }

    [SerializeField]
    private TMP_Text _questLabel,
                    _questValue;

    private BaseQuest quest;

    public void SetUp(BaseQuest q)
    {
        quest = q;
        LabelText = $"- {quest.TaskText}";
        quest.OnUpdateProgress += UpdateProgress;
        UpdateProgress(q);
    }

    public void UpdateProgress(BaseQuest q)
    {
        ProgressText = quest.GetProgressText();
    }
}
