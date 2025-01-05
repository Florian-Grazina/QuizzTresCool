using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quizz : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI questionText;
    [SerializeField] protected QuestionSO question;
    [SerializeField] protected GameObject[] answerButtons;

    protected int correctAnswerIndex;
    [SerializeField] protected Sprite defaultAnswerSprite;
    [SerializeField] protected Sprite correctAnswerSprite;

    protected void Start()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
        }
        else
        {
            int correctAnswerIndex = question.GetCorrectAnswerIndex();
            questionText.text = "Babuino, the correct answer is: " + question.GetAnswer(correctAnswerIndex);
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        }
        buttonImage.sprite = correctAnswerSprite;
    }
}
