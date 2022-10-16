using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMROnStart : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.transform.parent = GameObject.FindGameObjectWithTag("Map").transform;
    }
}
