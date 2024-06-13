
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GWEndGame : MonoBehaviour
{
    public TextMeshProUGUI pontuacaoText;

    // Start is called before the first frame update
    void Start()
    {
        pontuacaoText.text = GWGameManager.getPontuacao().ToString();

    }
    public void GameRestart()
    {
        GWGameManager.setPontuacao(0);
        SceneManager.LoadScene("GWMenuDificuldade");
    }


}
