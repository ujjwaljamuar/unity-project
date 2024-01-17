using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
    public VideoPlayer videoPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerExit.Invoke();

            // Stop the video when the player exits the trigger
            if (videoPlayer != null)
            {
                videoPlayer.Stop();
            }
        }
    }
}
