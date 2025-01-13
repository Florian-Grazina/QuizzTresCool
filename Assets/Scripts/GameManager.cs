using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected Quizz quizz;
    protected EndScreen endScreen;

    protected void Start()
    {
        quizz = FindFirstObjectByType<Quizz>();
        endScreen = FindFirstObjectByType<EndScreen>();

        quizz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    protected void Update()
    {
        
    }
}
