using UnityEngine;
using UnityEngine.Video;

public class PlayerTutorial : MonoBehaviour
{

    [SerializeField] private string videoName;
    void Start()
    {
        PlayVideo(videoName);
    }
    public void PlayVideo(string videoFileName)
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        Debug.Log(videoFileName);
        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}
