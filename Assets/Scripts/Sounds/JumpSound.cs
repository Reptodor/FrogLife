using System;
using UnityEngine;
using UnityEngine.Events;

public class JumpSound : MonoBehaviour
{
    [SerializeField] private UnityEvent JumpEvent;
    [SerializeField] private UnityEvent LandEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerAnimation>() != null)
        {
            LandEvent.Invoke();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerAnimation>() != null)
        {
            JumpEvent.Invoke();
        }
    }
}
