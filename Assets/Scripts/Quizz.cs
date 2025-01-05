using TMPro;
using UnityEngine;

public class Quizz : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI questionText;
    [SerializeField] protected QuestionSO question;
    [SerializeField] protected GameObject[] answerButtons;

    protected void Start()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }
}
