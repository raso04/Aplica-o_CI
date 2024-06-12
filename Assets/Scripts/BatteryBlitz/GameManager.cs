using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static int score = 0;

    public static void IncrementRightAnswer()
    {
        score++;
    }

    public static void IncrementWrongAnswer()
    {
        score--;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void Reset()
    {
        score = 0;
    }
}
