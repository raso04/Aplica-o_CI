using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunner : MonoBehaviour
{
    [Range(0, 2)]
    [SerializeField] private int timer;

    [Range(0, 30)]
    [SerializeField] private int matchTimer;

    [SerializeField] private List<GameObject> listMoles;

    private System.Random _randomNumberGenerator;
    private float currentTimer;

    [SerializeField] private TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        _randomNumberGenerator = new System.Random();
        currentTimer = 0;
        StartCoroutine(ChangeMole());
    }

    IEnumerator ChangeMole()
    {
        while (currentTimer < matchTimer)
        {
            yield return new WaitForSeconds(timer);
            listMoles.ForEach(item => item.SetActive(false));
            int randomNumber = _randomNumberGenerator.Next(0, listMoles.Count);
            listMoles[randomNumber].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer > matchTimer || GameManager.GetScore() < 0)
        {
            SceneManager.LoadScene("BatteryFinal");
        }

        currentTimer += Time.deltaTime;

        // Subtract elapsed time every frame
        float NumberOfSeconds = matchTimer - currentTimer;
        float seconds = Mathf.FloorToInt(NumberOfSeconds % 60);

        timerText.text = $"{seconds:00}";
    }
}
