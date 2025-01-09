using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    protected int correctAnswers = 0;
    protected int questionsSeen = 0;

    public int GetCorrectAnswers() => correctAnswers;
    public void IncrementCorrectAnswers() => correctAnswers++;

    public int GetQuestionsSeen() => questionsSeen;
    public void IncrementQuestionsSeen() => questionsSeen++;

    public int GetScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float)questionsSeen * 100);
    }
}
