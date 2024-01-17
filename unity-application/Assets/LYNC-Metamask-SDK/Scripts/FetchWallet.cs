using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class FetchWallet : MonoBehaviour
{
    [SerializeField] private Text WalletText;

    void Start()
    {
        WalletText.text = PlayerPrefs.GetString("WalletAddress");
    }

    public void GoToNextScene()
    {
        // int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        // SceneManager.LoadScene(nextSceneIndex);

        string userRole = PlayerPrefs.GetString("UserRole", "");
        if (userRole == "internal")
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else{
            SceneManager.LoadScene(5);
        }
    }

//     public void GoToNextScene()
//     {
//         string userRole = PlayerPrefs.GetString("UserRole", "");
//         if (userRole == "internal")
//         {
//             int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
//             SceneManager.LoadScene(nextSceneIndex);
//         }
//         else{
//             SceneManager.LoadScene(5);
//         }

//     }
}
