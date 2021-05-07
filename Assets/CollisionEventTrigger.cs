using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollisionEventTrigger : MonoBehaviour
{
    public string TriggerObjectName;
    public UnityEvent eventToTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == TriggerObjectName)
        {
            eventToTrigger.Invoke();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == TriggerObjectName)
        {
            eventToTrigger.Invoke();
        }
    }
}
