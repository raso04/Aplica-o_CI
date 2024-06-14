using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bgm : MonoBehaviour
{
    [SerializeField] public Sprite sprOn;
    [SerializeField] public Sprite sprOff;

    private bool isPlaying = true;

    private void Awake()
    {
        GameObject objBGM = GameObject.Find("BGM");
        DontDestroyOnLoad(objBGM);
        SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to the sceneLoaded event
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the sceneLoaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeButton(); // Initialize the button when a new scene is loaded
    }

    private void InitializeButton()
    {
        GameObject buttonObject = GameObject.Find("btn_Musica");
        if (buttonObject == null)
        {
            Debug.LogWarning("Button 'btn_Musica' not found in the scene.");
            return;
        }

        Button btn = buttonObject.GetComponent<Button>();
        Image image = buttonObject.GetComponent<Image>();

        btn.onClick.RemoveAllListeners();

        if (isPlaying)
        {
            btn.onClick.AddListener(StopMusic);
            image.sprite = sprOn;
        }
        else
        {
            btn.onClick.AddListener(PlayMusic);
            image.sprite = sprOff;
        }
    }

    public void StopMusic()
    {
        GameObject objBGM = GameObject.Find("BGM");
        if (objBGM != null)
        {
            objBGM.GetComponent<AudioSource>().volume = 0;
            isPlaying = false;
            InitializeButton();
        }
    }

    public void PlayMusic()
    {
        GameObject objBGM = GameObject.Find("BGM");
        if (objBGM != null)
        {
            objBGM.GetComponent<AudioSource>().volume = 0.69f;
            isPlaying = true;
            InitializeButton();
        }
    }
}
