using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToRoom0 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0); // assuming "Room0" is the name of the scene
    }
}
