using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLightOnStart : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<Light>().enabled = false;
    }
}
