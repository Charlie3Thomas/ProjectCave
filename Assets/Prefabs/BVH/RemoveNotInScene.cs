using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveNotInScene : MonoBehaviour
{
    private bool collosion_occurred = false;

    private void LateUpdate()
    {
        if (collosion_occurred)
        {
            Destroy(this.GetComponent<SphereCollider>()); // Remove Sphere collider from BVH node
            Destroy(this.GetComponent<Rigidbody>()); // Remove Rigidbody from BVH node
            Destroy(this); // Remove this script from BVH node to prevent future updates and trigger events
        }
        else
        {
            Debug.Log("BVH node deleted");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collosion_occurred)
            return;

        if (other.gameObject.tag == "Cave")
        {
            collosion_occurred = true;
            //Debug.Log("Collision");
            //Destroy(this.gameObject);
        }
    }

}
