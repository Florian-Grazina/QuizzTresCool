using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] protected float timeToAnswerquestion = 30f;
    [SerializeField] protected float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;

    public bool IsAnsweringQuestion = false;
    public float fillFraction;

    protected float timerValue;

    protected void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (IsAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToAnswerquestion;
            }
            else
            {
                IsAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                IsAnsweringQuestion = true;
                timerValue = timeToAnswerquestion;
                loadNextQuestion = true;
            }

            Debug.Log(IsAnsweringQuestion + " / Timer: " + timerValue + " / Timer: " + fillFraction);
        }
    }
}
