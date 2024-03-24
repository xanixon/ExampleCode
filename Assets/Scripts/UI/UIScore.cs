using TMPro;
using UnityEngine;
using Zenject;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private ScoreHandler _score;
    [Inject]
    public void Construct(ScoreHandler score)
    {
        _score = score;
    }
    // Start is called before the first frame update
    void Start()
    {
        _score.OnScoreChanged += updateScore;
    }

    protected void updateScore(int score)
    {
        text.text = score.ToString();
    }
}
