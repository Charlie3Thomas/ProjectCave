using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DisableMROnStart : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.transform.parent = GameObject.FindGameObjectWithTag("Map").transform;
        StartCoroutine(RemoveMeshCol(2));
    }

    IEnumerator RemoveMeshCol(float _delay)
    {
        //Debug.Log("Starting IEnumerator");
        yield return new WaitForSeconds(_delay);
        //Debug.Log("Sanity Check");
        MeshCollider[] mesh_colliders = this.gameObject.GetComponents<MeshCollider>();
        foreach(MeshCollider mc in mesh_colliders)
        {
            if(mc.isTrigger)
            {
                //Debug.Log("Destroying mesh trigger");
                Destroy(mc);
            }
        }
    }
}
