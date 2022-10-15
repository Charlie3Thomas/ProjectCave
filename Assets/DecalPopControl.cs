using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalPopControl : MonoBehaviour
{
    private bool col_checked = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Decal") && col_checked)
        {
            col_checked = true;
            Destroy(this);
        }
    }

}
