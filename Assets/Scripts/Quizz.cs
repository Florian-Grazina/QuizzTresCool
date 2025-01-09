using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quizz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] protected TextMeshProUGUI questionText;
    [SerializeField] protected List<QuestionSO> questions = new();
    protected QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] protected GameObject[] answerButtons;
    protected int correctAnswerIndex;
    bool hasAnswered;

    [SerializeField] protected Sprite defaultAnswerSprite;
    [SerializeField] protected Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] protected Image timerImage;
    protected Timer timer;

    [Header("Score")]
    [SerializeField] protected TextMeshProUGUI scoreText;
    protected ScoreKeeper scoreKeeper;

    protected void Start()
    {
        timer = FindFirstObjectByType<Timer>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    protected void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if(timer.loadNextQuestion)
        {
            hasAnswered = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnswered && !timer.IsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    #region public methods
    public void OnAnswerSelected(int index)
    {
        hasAnswered = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.GetScore() + "%";
    }
    #endregion

    #region private methods
    private void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            Debug.Log("Getting next question");

            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestions();
            scoreKeeper.IncrementQuestionsSeen();
        }
    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if(questions.Contains(currentQuestion))
            questions.Remove(currentQuestion);
    }

    private void DisplayAnswer(int index)
    {
        if (currentQuestion == null)
            return;

        Image buttonImage;

        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            int correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            questionText.text = "Babuino, the correct answer is: " + currentQuestion.GetAnswer(correctAnswerIndex);
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        }
        buttonImage.sprite = correctAnswerSprite;
    }

    private void DisplayQuestions()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
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
