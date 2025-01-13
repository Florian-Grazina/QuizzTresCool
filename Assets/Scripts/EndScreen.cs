using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI finalScoreAmount;
    protected ScoreKeeper scoreKeeper;

    protected void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        finalScoreAmount.text = $"{scoreKeeper.GetScore()}%";
    }
}
