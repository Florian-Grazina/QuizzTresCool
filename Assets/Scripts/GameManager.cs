using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected Quizz quizz;
    protected EndScreen endScreen;

    protected void Awake()
    {
        quizz = FindFirstObjectByType<Quizz>();
        endScreen = FindFirstObjectByType<EndScreen>();
    }

    protected void Start()
    {
        quizz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    protected void Update()
    {
        if(quizz.isComplete)
        {
            quizz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
