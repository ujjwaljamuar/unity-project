using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around the local Y-axis
        transform.Rotate(0f, 50f * Time.deltaTime, 0f, Space.Self);
    }
}
