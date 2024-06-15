using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PixelFinalSceneManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;

    public void Start()
    {
        timeText.text = PixelGameManager.GetSeconds().ToString();
    }

    public void TestAgain()
    {
        GameManager.Reset();
        SceneManager.LoadScene("PixelMenuDificuldade");
    }
}