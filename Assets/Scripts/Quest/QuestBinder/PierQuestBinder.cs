using UnityEngine;
using Zenject;

public class PierQuestBinder : QuestBinder
{
    [SerializeField] private VisitPlaceQuest _visitQuest = new VisitPlaceQuest();
    private TriggerZone _pierTrigger;

    [Inject]
    public void Construct([Inject(Id = "EndLevel")] TriggerZone endLevelTrigger)
    {
        _pierTrigger = endLevelTrigger;
    }
    // Start is called before the first frame update
    void Start()
    {
        _pierTrigger.gameObject.SetActive(false);
        _visitQuest.SetTriggerZone(_pierTrigger);
        _visitQuest.Init();
    }
    protected override void onQuestComplited(BaseQuest quest)
    {
        completedQuests++;
        if (completedQuests >= questCount)
        {
            _pierTrigger.gameObject.SetActive(true);
            questHolder.AddQuest(_visitQuest);
            _visitQuest.OnWin += visitPierHandler;
        }
    }

    protected void visitPierHandler(BaseQuest quest)
    {
        OnLevelComplete?.Invoke();
    }
}
