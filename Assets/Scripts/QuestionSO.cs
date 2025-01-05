using UnityEngine;


[CreateAssetMenu(menuName = "Quizz Question", fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] protected string question = "Enter new question text here";

    public string GetQuestion() => question;
}
