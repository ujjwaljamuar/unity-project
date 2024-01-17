// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // public class NewBehaviourScript : MonoBehaviour
// // {
// //     // Start is called before the first frame update
// //     void Start()
// //     {
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// // }

// public class Door = MonoBehaviour
// {
//     public bool IsOpen = false;
//     [SerializeField]
//     private bool IsRotatingDoor = true;
//     [SerializeField]
//     private float speed = 1fs;
//     [Header("Rotation Configs")]
//     [SerializeField]
//     private float RotationAmount = 90f;
//     [SerializeField]
//     private float ForwardDirection = 0;

//     private Vector3 StartRotation;
//     private Vector3 Forward;

//     private coroutine AnimationCoroutine;

//     private void Awake()
//     {
//         StartRotation = transform.rotation.eulerAngles
//         //since "forward" actually is pointing into the door frame, choose a direction to think about as "forward"
//         Forward = transform.right;
//     }

//     public void Open(Vector3 UserPosition)
//     {
//         if(!IsOpen)
//         {
//             if (AnimationCoroutine != null)
//             {
//                 StopCoroutine(AnimationCoroutine);
//             }
//             if(IsRotatingDoor)
//             {
//                 float dot = Vector3.Dot(Forward, (UserPosition - transform.position).normalized);
//                 Debug.Log($"Dot: {dot.ToString("N3")}");
//                 AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
//             }
//         }
//     }

//     private IEnumerator DoRotationOpen(float ForwardAmount)
//     {
//         Quaternion startRotation = transform.rotation;
//         Quaternion endRotation;
        
//         if(ForwardAmount >= ForwardAmount)
//         {
//             endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y - RotationAmount, 0));
//         }
//         else
//         {
//             endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y + RotationAmount));
//         }
//         IsOpen = true;
//         float time = 0;
//         while (time < 1)
//         {
//             transform.rotation = Quaternion.Slerp(StartRotation, endRotation, time);
//             yield return null;
//             time += Time.deltaTime * Speed;
//         }
//     }
//     public void close()
//     {
//         if(IsOpen)
//         {
//             if(AnimationCoroutine != null)
//             {
//                 StopCoroutine(AnimationCoroutine);
//             }
//             if(IsRotatingDoor)
//             {
//                 AnimationCoroutine = StartCoroutine(DoRotationClose());
//             }
//         }
//     }
//     private IEnumerator DoRotationClose()
//     {
//         Quaternion startRotation = transform.rotation;
//         Quaternion endRotation = Quaternion.Euler(StartRotation);

//         IsOpen = False;

//         float time = 0;
//         while (time < 1)
//         {
//             transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
//             yield return null;
//             time += time.deltaTime * Speed;
//         }
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField]
    private bool IsRotatingDoor = true;
    [SerializeField]
    private float Speed = 1f;
    [Header("Rotation Configs")]
    [SerializeField]
    private float RotationAmount = 90f;
    [SerializeField]
    private float ForwardDirection = 0;

    private Vector3 StartRotation;
    private Vector3 Forward;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        //since "forward" actually is pointing into the door frame, choose a direction to think about as "forward"
        Forward = transform.right;
    }

    public void Open(Vector3 UserPosition)
    {
        if (!IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            if (IsRotatingDoor)
            {
                float dot = Vector3.Dot(Forward, (UserPosition - transform.position).normalized);
                Debug.Log($"Dot: {dot.ToString("N3")}");
                AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
            }
        }
    }

    private IEnumerator DoRotationOpen(float ForwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if (ForwardAmount >= ForwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y - RotationAmount, 0));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y + RotationAmount, 0));
        }
        IsOpen = true;
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    public void Close()
    {
        if (IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            if (IsRotatingDoor)
            {
                AnimationCoroutine = StartCoroutine(DoRotationClose());
            }
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(StartRotation);

        IsOpen = false;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }
}
