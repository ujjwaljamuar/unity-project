using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoClip englishVideo;
    public VideoClip spanishVideo;
    public VideoClip frenchVideo;

    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";

        // Set up video clips
        videoPlayer.clip = englishVideo; // Default video

        // Start playing the default video
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        // Play the video
        videoPlayer.Play();
    }

    public void ChangeLanguage(string language)
    {
        // Change the video based on language selection
        switch (language)
        {
            case "English":
                videoPlayer.clip = englishVideo;
                break;
            case "Spanish":
                videoPlayer.clip = spanishVideo;
                break;
            case "French":
                videoPlayer.clip = frenchVideo;
                break;
            // Add more cases for other languages if needed

            default:
                // Handle default case (perhaps play a default video)
                videoPlayer.clip = englishVideo;
                break;
        }

        // Stop the current video and play the new one
        videoPlayer.Stop();
        StartCoroutine(PlayVideo());
    }
}
