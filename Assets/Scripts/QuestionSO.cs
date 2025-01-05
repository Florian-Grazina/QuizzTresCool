using UnityEngine;


[CreateAssetMenu(menuName = "Quizz Question", fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] protected string question = "Enter new question text here";
    [SerializeField] protected string[] answers = new string [4];
    [SerializeField] protected int correctAnswerIndex;

    #region public methods
    public string GetQuestion() => question;
    public string GetAnswer(int index) => answers[index];
    public int GetCorrectAnswerIndex() => correctAnswerIndex;
    #endregion
}
