// using TMPro;
// using UnityEngine;

// public class PlayerActions : MonoBehaviour
// {
//     [SerializeField]
//     private TextMeshPro UseText;
//     [SerializeField]
//     private Transform Camera;
//     [SerializeField]
//     private float MaxUseDistance = 5f;
//     [SerializeField]
//     private LayerMask UseLayers;

//     public void OnUse()
//     {
//         if(Physics.Raycast(Camera.position,Camera.Forward, out RaycastHit hit, MaxUseDistance, UseLayers))
//         {
//             if(hit.collider.TryGetComponent<Door>(out Door door))
//             {
//                 if(door.IsOpen)
//                 {
//                     door.Close();
//                 }
//                 else
//                 {
//                     door.Open(transform.position);
//                 }
//             }
//         }
//     }
//     private void Update()
//     {
//         if(Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers)
//         && hit.collider.TryGetComponent<Door>(out Door door))
//         {
//             if(door.IsOpen)
//             {
//                 UseText.SetText("Close \"E\"");
//             }

//             else
//             {
//                 UseText.SetText("Open \"E\"");
//             }
//             UseText.gameObject.SetActive(true);
//             UseText.transform.position = hit.point - (hit.point - GetComponent<Camera>().position).normalized * 0.01f;
//             UseText.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);
//         }
//         else
//         {
//             UseText.gameObject.SetActive(false);
//         }
//     }
// }
using TMPro;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro UseText;
    [SerializeField]
    private Camera PlayerCamera; // Changed type to Camera
    [SerializeField]
    private float MaxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    public void OnUse()
    {
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            Door door = hit.collider.GetComponent<Door>(); // Changed to GetComponent<Door>()
            if (door != null)
            {
                if (door.IsOpen)
                {
                    door.Close();
                }
                else
                {
                    door.Open(transform.position);
                }
            }
        }
    }

    private void Update()
    {
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out RaycastHit hit, MaxUseDistance, UseLayers)
            && hit.collider.TryGetComponent<Door>(out Door door))
        {
            if (door.IsOpen)
            {
                UseText.SetText("Close \"E\"");
            }
            else
            {
                UseText.SetText("Open \"E\"");
            }

            UseText.gameObject.SetActive(true);
            UseText.transform.position = hit.point - (hit.point - PlayerCamera.transform.position).normalized * 0.01f;
            UseText.transform.rotation = Quaternion.LookRotation((hit.point - PlayerCamera.transform.position).normalized);
        }
        else
        {
            UseText.gameObject.SetActive(false);
        }
    }
}
