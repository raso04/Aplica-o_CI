using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PixelTimerScript : MonoBehaviour
{
    private TMP_Text timerText;
    private float currentTimer;
    private bool isCounting;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TMP_Text>();
        currentTimer = 0;
        isCounting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCounting)
        {
            return;
        }
        currentTimer += Time.deltaTime;
        //Subtract elapsed time every frame
        float seconds = Mathf.FloorToInt(currentTimer % 60);
        timerText.text = $"{seconds:0}";
        PixelGameManager.SetSeconds(Convert.ToInt32(seconds));
    }

    public int GetTimerAndStop()
    {
        isCounting = false;
        return (int)currentTimer;
    }
}

