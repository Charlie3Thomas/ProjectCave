using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodySetup : MonoBehaviour
{
    Rigidbody p_rb;
    private void OnEnable()
    {
        p_rb = this.GetComponent<Rigidbody>();

        p_rb.interpolation = RigidbodyInterpolation.Interpolate;
        p_rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        p_rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
