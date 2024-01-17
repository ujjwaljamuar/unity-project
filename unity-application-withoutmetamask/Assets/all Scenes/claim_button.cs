using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaimButtonScript : MonoBehaviour
{
    // The URL you want to redirect to when the claim button is pressed
    public string claimURL = "https://opensea.io/assets/ethereum/0x46ac8540d698167fcbb9e846511beb8cf8af9bd8/220059";

    public void OnClaimButtonClick()
    {
        // Open the provided URL when the claim button is pressed
        Application.OpenURL(claimURL);
    }
}