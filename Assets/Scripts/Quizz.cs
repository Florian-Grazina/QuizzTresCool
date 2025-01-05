using TMPro;
using UnityEngine;

public class Quizz : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI questionText;
    [SerializeField] protected QuestionSO question;

    protected void Start()
    {
        questionText.text = question.GetQuestion();
    }
}
