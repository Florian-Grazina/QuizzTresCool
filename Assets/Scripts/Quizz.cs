using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quizz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] protected TextMeshProUGUI questionText;
    [SerializeField] protected QuestionSO question;

    [Header("Answers")]
    [SerializeField] protected GameObject[] answerButtons;
    protected int correctAnswerIndex;

    [SerializeField] protected Sprite defaultAnswerSprite;
    [SerializeField] protected Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] protected Image timerImage;
    protected Timer timer;
    protected void Start()
    {
        DisplayQuestions();
    }

    #region public methods
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

        SetButtonState(false);
        buttonImage.sprite = correctAnswerSprite;
    }
    #endregion

    #region private methods
    private void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestions();
    }

    private void DisplayQuestions()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    private void SetButtonState(bool state)
    {
        foreach (GameObject button in answerButtons)
            button.GetComponent<Button>().interactable = state;
    }

    private void SetDefaultButtonSprite()
    {
        foreach (GameObject button in answerButtons)
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
    #endregion
}
