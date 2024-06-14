using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class bgm : MonoBehaviour
{
    [SerializeField] public Sprite sprOn;
    [SerializeField] public Sprite sprOff;

    private bool isPlaying = true;

    private void Awake()
    {
        // Check if a BGM object already exists
        GameObject existingBGM = GameObject.Find("BGM");

        if (existingBGM != null && existingBGM != gameObject)
        {
            // Destroy the new instance if an existing one is found
            Destroy(gameObject);
        }
        else
        {
            // Assign this as the existing BGM instance
            gameObject.name = "BGM";
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to the sceneLoaded event
            StartCoroutine(InitializeButtonWithDelay());
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the sceneLoaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(InitializeButtonWithDelay()); // Initialize the button with a delay when a new scene is loaded
    }

    private IEnumerator InitializeButtonWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // Slight delay to ensure the scene is fully loaded

        GameObject buttonObject = GameObject.Find("btn_Musica");
        if (buttonObject == null)
        {
            Debug.LogWarning("Button 'btn_Musica' not found in the scene.");
            yield break;
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
            StartCoroutine(InitializeButtonWithDelay());
        }
    }

    public void PlayMusic()
    {
        GameObject objBGM = GameObject.Find("BGM");
        if (objBGM != null)
        {
            objBGM.GetComponent<AudioSource>().volume = 0.69f;
            isPlaying = true;
            StartCoroutine(InitializeButtonWithDelay());
        }
    }
}
