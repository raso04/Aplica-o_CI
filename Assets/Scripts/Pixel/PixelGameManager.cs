using UnityEngine;
using UnityEngine.SceneManagement;

public class PixelGameManager : MonoBehaviour
{
    private static int _rightAnswers = 0;

    public static int dificuldade = 0;

    public static void IncrementRightAnswer()
    {
        _rightAnswers++;
        switch (dificuldade)
        {
            case 0:
                if (_rightAnswers == 9)
                {
                    SceneManager.LoadScene("PixelEndGame");
                }
                break;
            case 1:
                if (_rightAnswers == 25)
                {
                    SceneManager.LoadScene("PixelEndGame");
                }
                break;
            case 2:
                if (_rightAnswers == 49)
                {
                    SceneManager.LoadScene("PixelEndGame");
                }
                break;
        }

    }

    public static int GetRightAnswer()
    {
        return _rightAnswers;
    }

    private static int seconds;

    public static void SetSeconds(int newSeconds)
    {
        seconds = newSeconds;
    }

    public static int GetSeconds()
    {
        return seconds;
    }

    public static void Reset()
    {
        seconds = 0;
        _rightAnswers = 0;
    }
}
