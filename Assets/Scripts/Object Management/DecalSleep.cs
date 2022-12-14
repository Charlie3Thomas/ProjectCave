using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalSleep : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {        
        if (other.tag == "Player")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
