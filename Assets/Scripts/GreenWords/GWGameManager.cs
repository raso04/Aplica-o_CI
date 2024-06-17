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
    public Animator animator;

    private QuestionData[] perguntas;
    private static int currentQuestionIndex = 0;
    private static int difficulty = 0;
    private static int pontuacao = 0;

    void Start()
    {
        // Create an instance of QuestionData
        perguntas = new QuestionData[]{
            new QuestionData("VIDRO","V__RO","_I_RO","V___O", //palavra, fácil, médio, difícil
            new string[] { "VIDRO", "VIRRO","VIRTO","VISPO"}), //respostas

            new QuestionData("VERDE","VE__E","_ER__","V___E",
            new string[] { "VERDE", "VERTE","VOLHE","VARTE"}),

            new QuestionData("GARRAFA", "G_RR_FA", "G_R__FA", "G_____A",
            new string[] { "GARRAFA", "GARTAFA", "GARLATA", "GARRASA" }),

            new QuestionData("RECICLAR", "R_CI__AR", "R_C___A_", "R______R",
            new string[] { "RECICLAR", "RECIRLAR", "RECITALR", "RECICLIR" }),

            new QuestionData("ECOPONTO", "E__P__T_", "___PO_TO","E______O",
            new string[] { "ECOPONTO", "ECONPOTO", "ECOPTNOO", "ECOPOTON" }),

            new QuestionData("RESÍDUO", "R_SÍ_UO", "_E_Í__O", "R_____O",
            new string[] { "RESÍDUO", "RATATRE", "REIDUSO", "RAPARTO" }),

            new QuestionData("CAIXOTE", "CA_X_TE", "_A__O__","C_____E",
            new string[] { "CAIXOTE", "COAXOTE", "CLICATE", "CAEXOTE" }),

            new QuestionData("FRASCO", "F__A__", "_R__C_","F__S__",
            new string[] { "FRASCO", "FRISPO", "FRASIO", "FRASRO" }),

            new QuestionData("REDUZIR", "R_DU_IR", "_E__Z_R","R_____R",
            new string[] { "REDUZIR", "RETULIR", "REDUZAR", "REPUZAR" }),

            new QuestionData("CUIDAR", "C__D_R", "_U__A_", "C____R",
            new string[] { "CUIDAR", "CORRAR", "CUIDIR", "CULTAR" })

        };





        // Display the question and answers
        DisplayQuestion();
    }
    void DisplayQuestion()
    {
        animator.ResetTrigger("StartAppear");
        QuestionData pergunta = perguntas[currentQuestionIndex];
        // Set the question text based on the difficulty
        // Shuffle the response arrays
        for (int i = 0; i < perguntas.Length; i++)
        {
            QuestionData.ShuffleRespostas(perguntas[i].respostas);

        }

        switch (difficulty)
        {
            case 0:
                questionText.text = pergunta.dificuldade1;
                SetAnswers(pergunta.respostas, pergunta.palavra);
                break;
            case 1:
                questionText.text = pergunta.dificuldade2;
                SetAnswers(pergunta.respostas, pergunta.palavra);
                break;
            case 2:
                questionText.text = pergunta.dificuldade3;
                SetAnswers(pergunta.respostas, pergunta.palavra);
                break;
        }
    }

    void SetAnswers(string[] respostas, string certa) //Mudar as respostas
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
        answerButton1.onClick.RemoveAllListeners();
        answerButton2.onClick.RemoveAllListeners();
        answerButton3.onClick.RemoveAllListeners();
        answerButton4.onClick.RemoveAllListeners();

        if (selectedAnswer == correctAnswer) //Se a resposta estiver certa
        {
            successAudio.Play();
            AddPoint();
            blinker.color = Color.green;
            questionText.text = perguntas[currentQuestionIndex].palavra;
            animator.SetTrigger("StartFall");
            if (perguntas.Length - 1 == currentQuestionIndex) //Se for a ultima
            {
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("GWEndGame");
            }
            else
            {
                // Wait for 3 seconds
                yield return new WaitForSeconds(3);
                blinker.color = new Color(27 / 255f, 84 / 255f, 25 / 255f, 1.0f);
                currentQuestionIndex++;
                animator.ResetTrigger("StartFall");
                DisplayQuestion();
                animator.SetTrigger("StartAppear");

            }

        }
        else //Se estiver errada
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
    public static void setDificuldade(int dif)
    {
        difficulty = dif;
    }
    public static void setPontuacao(int pts)
    {
        pontuacao = pts;
    }
    public static void resetAll()
    {
        pontuacao = 0;
        currentQuestionIndex = 0;
    }
}