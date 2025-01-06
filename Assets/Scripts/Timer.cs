using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] protected float timeToAnswerquestion = 30f;
    [SerializeField] protected float timeToShowCorrectAnswer = 10f;

    public bool IsAnsweringQuestion = false;

    protected float timerValue;

    protected void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(timerValue <= 0)
        {
            IsAnsweringQuestion = !IsAnsweringQuestion;
            timerValue = IsAnsweringQuestion ? timeToAnswerquestion : timeToShowCorrectAnswer;
        }
    }
}
