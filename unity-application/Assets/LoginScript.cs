using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    // Replace with your backend API URL
    // http://13.233.57.7/userauth/login
    private static string apiUrl = "http://13.233.57.7/userauth/login";

    public InputField emailInput;
    public InputField passwordInput;

    [Serializable]
    public class LoginData
    {
        public string email;
        public string password;
    }

    [Serializable]
    public class LoginResponse
    {
        public bool success;
        public string message;
        public UserData user;

        [Serializable]
        public class UserData
        {
            public string _id;
            public string name;
            public string email;
            public string password;
            public string role;
            public int __v;
        }
    }

    public void OnLoginButtonClick()
    {
        string email = emailInput.text.Trim().ToLower();
        string password = passwordInput.text.Trim();

        Debug.Log("Email: " + email);
        Debug.Log("Password: " + password);

        LoginData loginData = new LoginData
        {
            email = email,
            password = password
        };

        // Debug.Log("Line 1 complete");

        // Call the authentication coroutine directly
        StartCoroutine(SendLoginRequest(loginData));
    }

    IEnumerator SendLoginRequest(LoginData loginData)
    {
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(loginData));
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Debug.Log("Line 2 complete");

        UnityWebRequestAsyncOperation asyncOperation = request.SendWebRequest();

        // Debug.Log("Line 3 complete");

        // Wait for the request to complete
        while (!asyncOperation.isDone)
        {
            // Debug.Log("Line 4 complete");
            yield return null;
        }

        try
        {
            // Check for errors after the request is complete
            if (request.result == UnityWebRequest.Result.Success)
            {
                // Debug.Log("Line 5 complete");

                LoginResponse jsonResponse = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);

                // Debug.Log("Line 6 complete");

                if (jsonResponse.success)
                {
                    // Debug.Log("Line 7 complete");
                    string returnedName = jsonResponse.user.name;
                    string role = jsonResponse.user.role;
                    Debug.Log("Login successful! Welcome back, " + returnedName);
                    Debug.Log("Role, " + role);

                    Debug.Log("Connected with EC2, " + returnedName);

                    PlayerPrefs.SetString("UserRole", role);
                    PlayerPrefs.Save();

                    SceneManager.LoadScene(1);

                    // if(role == "internal"){
                    //     SceneManager.LoadScene(1);
                    // }
                    // else{
                    //     SceneManager.LoadScene(4);
                    // }
                    
                    // You can use the returned user information as needed


                }
                else
                {
                    // Debug.Log("Line 8 complete");
                    Debug.LogError("invalid" + jsonResponse.message);
                    // Handle the error if needed
                }
            }
            else
            {
                Debug.LogError("Login failed: " + request.error);
                // Handle the error if needed
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Exception during login: " + ex.Message);
            // Handle the exception if needed
        }
        finally
        {
            request.Dispose(); // Dispose of the UnityWebRequest
        }
    }
}



// PlayerPrefs.SetString("MyGlobalString", "Hello, Unity!");
//                     PlayerPrefs.Save();


// using UnityEngine;
// using UnityEngine.UI;


// public class LoginScript : MonoBehaviour
// {
//     public InputField usernameInput;
//     public InputField passwordInput;

//     public void OnLoginButtonClick()
//     {
//         string username = usernameInput.text;
//         string password = passwordInput.text;

//         Debug.Log("Username: " + username);
//         Debug.Log("Password: " + password);
//     }
// }
