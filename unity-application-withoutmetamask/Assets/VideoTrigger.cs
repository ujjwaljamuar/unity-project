
using UnityEngine;
using UnityEngine.Video;

public class VideoTrigger11 : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void OnTriggerEnter1(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            videoPlayer.Play();
        }
    }

    void OnTriggerExit1(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            videoPlayer.Stop();
        }
    }
}

