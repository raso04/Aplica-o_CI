using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneAction(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UnloadLoseScene()
    {
        SceneManager.UnloadSceneAsync("LoseScene");
    }
}