using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalSceneEcoMatch : MonoBehaviour
{
    [SerializeField] private TMP_Text answersText;

    public void Start()
    {
        answersText.text = GameManagerEcoMatch.GetSeconds().ToString();
    }

    public void TestAgain()
    {
        GameManager.Reset();
        SceneManager.LoadScene("ECOMenuDificuldade");
    }
}