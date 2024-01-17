// using System.Collections;
// using UnityEngine;

// public class SlidingDoor : MonoBehaviour
// {
//     public Transform door; // Assign the door object in the inspector
//     public float slideDistance = 2f; // Distance the door will slide
//     public float slideSpeed = 1f; // Speed the door will slide

//     private Vector3 _closedPosition;
//     private Vector3 _openPosition;
//     private bool _isOpen = false;
//     private Coroutine _currentCoroutine;

//     private void Start()
//     {
//         _closedPosition = door.position;
//         _openPosition = new Vector3(door.position.x + slideDistance, door.position.y, door.position.z);
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (!_isOpen)
//         {
//             if (_currentCoroutine != null)
//             {
//                 StopCoroutine(_currentCoroutine);
//             }
//             _currentCoroutine = StartCoroutine(SlideDoor(_openPosition));
//             _isOpen = true;
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (_isOpen)
//         {
//             if (_currentCoroutine != null)
//             {
//                 StopCoroutine(_currentCoroutine);
//             }
//             _currentCoroutine = StartCoroutine(SlideDoor(_closedPosition));
//             _isOpen = false;
//         }
//     }

//     private IEnumerator SlideDoor(Vector3 targetPosition)
//     {
//         while ((door.position - targetPosition).sqrMagnitude > 0.01f)
//         {
//             door.position = Vector3.Lerp(door.position, targetPosition, Time.deltaTime * slideSpeed);
//             yield return null;
//         }

//         door.position = targetPosition;
//     }
// }
// using System.Collections;
// using UnityEngine;

// public class SlidingDoor : MonoBehaviour
// {
//     public float openSpeed = 5f; // Speed at which the door opens
//     public float closeSpeed = 5f; // Speed at which the door closes
//     public Vector3 closedPosition; // Position of the door when closed
//     public Vector3 openPosition; // Position of the door when open

//     private bool isOpening = false;
//     private bool isClosing = false;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of your player game object
//         {
//             isOpening = true;
//             isClosing = false;
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of your player game object
//         {
//             isClosing = true;
//             isOpening = false;
//         }
//     }

//     private void Update()
//     {
//         if (isOpening)
//         {
//             transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);
//         }
//         else if (isClosing)
//         {
//             transform.position = Vector3.MoveTowards(transform.position, closedPosition, closeSpeed * Time.deltaTime);
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public GameObject door; // Assign your door GameObject here
    public float openPosition; // Assign the position value when door is open
    public float closedPosition; // Assign the position value when door is closed
    public float speed = 1.0f; // Speed of the door opening and closing

    private bool isOpen = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // Assuming your player GameObject has the tag "Player"
        {
            isOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOpen = false;
        }
    }

    void Update()
    {
        if (isOpen)
        {
            // Open the door
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, openPosition, door.transform.position.z), Time.deltaTime * speed);
        }
        else
        {
            // Close the door
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, closedPosition, door.transform.position.z), Time.deltaTime * speed);
        }
    }
}

