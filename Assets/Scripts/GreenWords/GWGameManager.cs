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
    static private int difficulty = 0;
    private static int pontuacao = 0;

    void Start()
    {
        // Create an instance of QuestionData
        perguntas = new QuestionData[]{
            new QuestionData("VIDRO","V__RO","_I_RO","V___O", //palavra, fácil, médio, difícil
            new string[] { "_ID__", "_IT__","_AI__","_AR__"}, //respostas fácil
            new string[] {"V_D__", "P_R__","L_O__","A_P__" }, //respostas médio
            new string[] { "VIDRO", "VIRRO","VIRTO","VISPO"}, //respostas dificil
            "_ID__", //resposta certa fácil
            "V_D__", //resposta certa médio
            "VIDRO"), //resposta certa difícil
            new QuestionData("VERDE","VE__E","_ER__","V___E",
            new string[] { "__RD_", "__RT_","__LT_","__CH_"},
            new string[] {"V__DE", "P__RO","L__TO","P__SE" },
            new string[] { "VERDE", "VERTE","VOLHE","VARTE"},
            "__RD_",
            "V__DE",
            "VERDE"),
            new QuestionData(
            "GARRAFA",
            "G_RR_FA",
            "G_R__FA",
            "G_____A",
            new string[] { "_A__A__", "_A__O__", "_O__O__", "_O__A__" },
            new string[] { "_A_RA__", "_A_LO__", "_E_RE__", "_O_TO__" },
            new string[] { "GARRAFA", "GARTAFA", "GARLATA", "GARRASA" },
            "_A__A__",
            "_A_RA__",
            "GARRAFA"),
            new QuestionData(
            "RECICLAR",
            "R_CI__AR",
            "R_C___A_",
            "R______R",
            new string[] { "_E__CL__", "_A__NH__", "_I__AL__", "_E__TL__" }, 
            new string[] { "_E_ICL_R", "_A_OCL_R", "_E_TLE_O", "_I_COR_R" },
            new string[] { "RECICLAR", "RECIRLAR", "RECITALR", "RECICLIR" },
            "E__CL", "E_ICL_R", "RECICLAR"),

            new QuestionData(
            "ECOPONTO",
            "E__P__T_",
            "___PO_TO",
            "E______O",
            new string[] { "_CO_ON_O", "_CO_LO_E", "_PO_TO_E", "_TE_AI_O" }, 
            new string[] { "ECO__N__", "PER__L__", "CAR__T__", "ECO__L__" },
            new string[] { "ECOPONTO", "ECONPOTO", "ECOPTNOO", "ECOPOTON" },
            "_CO_ON_O",
            "ECO__N__",
            "ECOPONTO"),

            new QuestionData("RESÍDUO", "R_SÍ_UO", "_E_Í__O", "R_____O",
            new string[] { "_E__D__", "_A__T__", "_E__L__", "_I__T__" }, 
            new string[] { "R_S_DU_", "P_R_TO_", "L_O_RR_", "R_P_DU_" },
            new string[] { "RESÍDUO", "RATATRE", "REIDUSO", "RAPARTO" },
            "_E__D__",
            "R_S_DU_",
            "RESÍDUO"),

            new QuestionData("CAIXOTE", "CA_X_TE", "_A__O__","C_____E",
            new string[] { "__I_O__", "__E_I__", "__A_A__", "__O_O__" }, 
            new string[] { "C_IX_TE", "P_AL_LO", "L_OT_DO", "C_LT_DE" },
            new string[] { "CAIXOTE", "COAXOTE", "CLICATE", "CAEXOTE" },
            "__I_O__",
            "C_IX_TE",
            "CAIXOTE"),

            new QuestionData("FRASCO", "F__A__", "_R__C_","F__S__",
            new string[] { "FR", "AS", "RA", "SC" }, 
            new string[] { "F_A", "P_R", "L_O", "A_P" },
            new string[] { "FRASCO", "FRISPO", "FRASIO", "FRASRO" },
            "FR",
            "F_A",
            "FRASCO"),

            new QuestionData("REDUZIR", "R_DU_IR", "_E__Z_R","R_____R",
            new string[] { "_E__Z__", "_A__R__", "_O__L__", "_I__T__" }, 
            new string[] { "R_DU_I_", "M_LO_A_", "L_DO_E_", "C_TE_I_" },
            new string[] { "REDUZIR", "RETULIR", "REDUZAR", "REPUZAR" },
            "_E__Z__",
            "R_DU_I_",
            "REDUZIR"),

            new QuestionData("CUIDAR", "C__D_R", "_U__A_", "C____R",
            new string[] { "_UI_A_", "_EO_E_", "_AI_O_", "_IO_E_" }, 
            new string[] { "C_ID_R", "P_AR_L", "C_OL_R", "L_AP_R" },
            new string[] { "CUIDAR", "CORRAR", "CUIDIR", "CULTAR" },
            "_UI_A_",
            "C_ID_R",
            "CUIDAR")

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

        if (selectedAnswer == correctAnswer) //Se a resposta estiver certa
        {
            successAudio.Play();
            AddPoint();
            blinker.color = Color.green;
            questionText.text = perguntas[currentQuestionIndex].palavra;

            if (perguntas.Length - 1 == currentQuestionIndex) //Se for a ultima
            {
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("GWEndGame");
            }
            else
            {
                // Wait for 3 seconds
                yield return new WaitForSeconds(3);
                Debug.Log(blinker.color);
                blinker.color = new Color(27 / 255f, 84 / 255f, 25 / 255f, 1.0f);
                Debug.Log(blinker.color);
                currentQuestionIndex++;
                DisplayQuestion();
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
}
