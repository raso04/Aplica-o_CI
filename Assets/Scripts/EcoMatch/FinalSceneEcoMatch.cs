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
        StartCoroutine(waitChange());


    }
    IEnumerator waitChange()
    {
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene("ECOMenuDificuldade");

    }

}