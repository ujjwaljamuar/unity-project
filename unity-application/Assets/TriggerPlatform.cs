using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    PlatformMoving platform; // Corrected the casing

    private void Start()
    {
        platform = GetComponent<PlatformMoving>(); // Corrected the casing
    }

    private void OnTriggerEnter(Collider other)
    {
        platform.canMove = true;
    }
}
