using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalParent : MonoBehaviour
{
    private void OnEnable()
    {
        if (GameObject.FindGameObjectWithTag("DecalContainer").transform != null)
        {
            this.transform.parent = GameObject.FindGameObjectWithTag("DecalContainer").transform;
        }
        else
        {
            Debug.LogError("There needs to be a Decal Container object in the scene tagged with \"DecalContainer\".");
        }
    }
}
