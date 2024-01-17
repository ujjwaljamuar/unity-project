using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonScript : MonoBehaviour
{
    // Reference to the panel GameObject
    public GameObject panelObject;

    // Call this method from the close button's onClick event
    public void ClosePanel()
    {
        // Make the panel invisible
        if (panelObject != null)
        {
            panelObject.SetActive(false);
            Debug.Log("Panel set to inactive");
        }
    }
}
