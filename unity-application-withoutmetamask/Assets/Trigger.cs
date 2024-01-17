using System;
using UnityEngine;
using UnityEngine.Events;
public class Trigger : MonoBehaviour
{
   [SerializeField] bool destroyOnTriggerEnter;
   [SerializeField] UnityEvent onTriggerEnter;
   [SerializeField] UnityEvent onTriggerExit;
   
   void OnTriggerEnter(Collider other)
   {
    
    onTriggerEnter.Invoke();
    if (destroyOnTriggerEnter)
    {
        Destroy(gameObject);
    }
   }
   void OnTriggerExit(Collider other)
   {
    
    onTriggerExit.Invoke();
}
}