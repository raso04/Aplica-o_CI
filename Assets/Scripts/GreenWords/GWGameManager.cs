using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GWGameManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button answerButton1;
    public Button answerButton2;
    public Button answerButton3;
    public Button answerButton4;
    public TextMeshProUGUI pontuacaoText;
    public Image blinker;
    public AudioSource successAudio;

    private QuestionData[] perguntas;
    private int currentQuestionIndex = 0;
    private int difficulty = 0;
    private static int pontuacao = 0;

    void Start()
    {
        // Create an instance of QuestionData
        perguntas = new QuestionData[]{
            new QuestionData("VIDRO","V__RO","_I_RO","V___O", //palavra, fácil, médio, difícil
            new string[] { "ID", "IT","AI","AR"}, //respostas fácil
            new string[] {"V_D", "P_R","L_O","A_P" }, //respostas médio
            new string[] { "VIDRO", "VIRRO","VIRTO","VISPO"}, //respostas dificil
            "ID", //resposta certa fácil
            "V_D", //resposta certa médio
            "VIDRO"), //resposta certa difícil
            new QuestionData("VERDE","VE__E","_ER__","V___E",
            new string[] { "RD", "RT","LT","CH"},
            new string[] {"V__DE", "P__RO","L__TO","P__SE" },
            new string[] { "VERDE", "VERTE","VOLHE","VARTE"},
            "RD",
            "V__DE",
            "VERDE"),
            new QuestionData(
            "GARRAFA",
            "G_RR_FA",
            "G_R__FA",
            "G_____A",
            new string[] { "A__A", "A__O", "O__O", "O__A" },
            new string[] { "A_RA", "A_LO", "E_RE", "O_TO" },
            new string[] { "GARRAFA", "GARTAFA", "GARLATA", "GARRASA" },
            "A__A",
            "G_R",
            "GARRAFA")
    };





        // Display the question and answers
        DisplayQuestion();
    }
    void DisplayQuestion()
    {
        QuestionData pergunta = perguntas[currentQuestionIndex];
        // Set the question text based on the difficulty
        // Shuffle the response arrays
        for (int i = 0; i < perguntas.Length; i++)
        {
            QuestionData.ShuffleRespostas(perguntas[i].respostas1);
            QuestionData.ShuffleRespostas(perguntas[i].respostas2);
            QuestionData.ShuffleRespostas(perguntas[i].respostas3);
        }

        switch (difficulty)
        {
            case 0:
                questionText.text = pergunta.dificuldade1;
                SetAnswers(pergunta.respostas1, pergunta.certa1);
                break;
            case 1:
                questionText.text = pergunta.dificuldade2;
                SetAnswers(pergunta.respostas2, pergunta.certa2);
                break;
            case 2:
                questionText.text = pergunta.dificuldade3;
                SetAnswers(pergunta.respostas3, pergunta.certa3);
                break;
        }
    }

    void SetAnswers(string[] respostas, string certa)
    {
        answerButton1.GetComponentInChildren<TextMeshProUGUI>().text = respostas[0];
        answerButton2.GetComponentInChildren<TextMeshProUGUI>().text = respostas[1];
        answerButton3.GetComponentInChildren<TextMeshProUGUI>().text = respostas[2];
        answerButton4.GetComponentInChildren<TextMeshProUGUI>().text = respostas[3];

        answerButton1.onClick.RemoveAllListeners();
        answerButton2.onClick.RemoveAllListeners();
        answerButton3.onClick.RemoveAllListeners();
        answerButton4.onClick.RemoveAllListeners();

        answerButton1.onClick.AddListener(() => StartCoroutine(manageAnswer(respostas[0], certa)));
        answerButton2.onClick.AddListener(() => StartCoroutine(manageAnswer(respostas[1], certa)));
        answerButton3.onClick.AddListener(() => StartCoroutine(manageAnswer(respostas[2], certa)));
        answerButton4.onClick.AddListener(() => StartCoroutine(manageAnswer(respostas[3], certa)));
    }
    // Coroutine that waits for 3 seconds before continuing
    IEnumerator manageAnswer(string selectedAnswer, string correctAnswer)
    {

        if (selectedAnswer == correctAnswer)
        {
            successAudio.Play();
            AddPoint();
            blinker.color = Color.green;
            questionText.text = perguntas[currentQuestionIndex].palavra;

            if (perguntas.Length - 1 == currentQuestionIndex)
            {
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("GWEndGame");
            }
            else
            {
                // Wait for 3 seconds
                yield return new WaitForSeconds(3);

                blinker.color = new Color(27, 84, 25);
                currentQuestionIndex++;
                DisplayQuestion();
            }

        }
        else
        {
            blinker.color = Color.red;
            questionText.text = perguntas[currentQuestionIndex].palavra;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("GWEndGame");
        }
    }

    void AddPoint()
    {
        pontuacao++;
        pontuacaoText.text = pontuacao.ToString();
    }
    public static int getPontuacao()
    {
        return pontuacao;
    }

}
