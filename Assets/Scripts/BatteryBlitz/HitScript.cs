using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnHit()
    {
        GameManager.IncrementRightAnswer();
    }

    public void OnMiss()
    {
        GameManager.IncrementWrongAnswer();
    }
}

