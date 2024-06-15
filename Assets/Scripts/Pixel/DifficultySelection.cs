using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelection : MonoBehaviour
{
    public void SelectEasy()
    {
        PixelGameManager.dificuldade = 0;
        SceneManager.LoadScene("PixelGameEasy");
    }

    public void SelectMedium()
    {
        PixelGameManager.dificuldade = 1;
        SceneManager.LoadScene("PixelGameMedium");
    }

    public void SelectHard()
    {
        PixelGameManager.dificuldade = 2;
        SceneManager.LoadScene("PixelGameHard");
    }
}
