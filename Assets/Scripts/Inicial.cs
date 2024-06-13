using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicial : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            Debug.Log("Animator component found!");
        }
        else
        {
            Debug.LogError("Animator component not found!");
        }
    }

    public void StartAnimation()
    {
        animator.ResetTrigger("Trigger");
        animator.SetTrigger("Trigger");
        Debug.Log("Animei");

        StartCoroutine(changeScene());
    }
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("Inicial2");
        Debug.Log("mudei de cena");

    }
}
