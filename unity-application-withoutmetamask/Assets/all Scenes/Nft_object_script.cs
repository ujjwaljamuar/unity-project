using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // Reference to the panel GameObject
    public GameObject panelObject;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object is the one you want
        if (other.CompareTag("Player"))  // Change "Player" to the tag of the object you want to trigger the panel
        {
            // Make the panel visible
            if (panelObject != null)
            {
                panelObject.SetActive(true);
            }
        }
    }
}
