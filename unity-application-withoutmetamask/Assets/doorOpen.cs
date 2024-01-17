using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    private Animator animatorDoor;

    // Start is called before the first frame update
    void Start()
    {
        animatorDoor = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        animatorDoor.SetBool("opendoor", true);
    }
}
