using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class QuestProgressPanel : MonoBehaviour
{
    

    [SerializeField] private RectTransform textParent;
    [SerializeField] private GameObject questLabelPrefab;
    private QuestHolder holder;

    [Inject]
    public void Construct(QuestHolder newHolder)
    {
        this.holder = newHolder;
        holder.OnQuestListUpdate += onQuestListUpdated;
    }

    private void Start()
    {
        drawQuests();
    }

    private void drawQuests()
    {
        foreach (BaseQuest q in holder.quests)
        {
            createQuestText(q);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(textParent);
    }
    private void createQuestText(BaseQuest q)
    {
        GameObject text = Instantiate(questLabelPrefab, textParent);
        QuestLabel ql = text.GetComponent<QuestLabel>();

        ql.SetUp(q);
    }

    private void onQuestListUpdated(QuestHolder holder)
    {
        int childCount = textParent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(textParent.GetChild(i).gameObject);
        }
        drawQuests();
    }
}
