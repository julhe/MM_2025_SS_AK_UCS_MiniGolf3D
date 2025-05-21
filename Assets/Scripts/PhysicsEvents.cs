using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsEvents : MonoBehaviour
{
    public UnityEvent TriggerEnter = new UnityEvent();
    public UnityEvent TriggerStay = new UnityEvent();
    public UnityEvent TriggerExit = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnterrichtBallScript>())
        {
            TriggerEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<UnterrichtBallScript>())
        {
            TriggerStay.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<UnterrichtBallScript>())
        {
            TriggerExit.Invoke();
        }
    }
}
