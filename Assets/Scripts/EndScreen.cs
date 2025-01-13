using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreAmount;
    protected ScoreKeeper scoreKeeper;

    protected void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        finalScoreAmount.text = $"{scoreKeeper.GetScore()}%";
    }
}
