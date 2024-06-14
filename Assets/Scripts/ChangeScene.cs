using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneAction(string sceneName)
    {
        StartCoroutine(waitChange(sceneName));
    }
    IEnumerator waitChange(string sceneName)
    {
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene(sceneName);

    }

    public void UnloadLoseScene()
    {
        SceneManager.UnloadSceneAsync("LoseScene");
    }
}