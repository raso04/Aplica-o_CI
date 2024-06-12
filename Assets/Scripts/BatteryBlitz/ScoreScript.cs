using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;

    // Start is called before the first frame update
    void Start()
    {
        // Nenhuma lógica específica no Start por enquanto
    }

    // Update is called once per frame
    void Update()
    {
        textField.text = GameManager.GetScore().ToString();
    }
}