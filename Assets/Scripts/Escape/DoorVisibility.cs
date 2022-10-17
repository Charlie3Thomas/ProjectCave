using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVisibility : MonoBehaviour
{
    [SerializeField] private Animator trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.SetTrigger("PopIn");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.SetTrigger("PopOut");
        }
    }
}
