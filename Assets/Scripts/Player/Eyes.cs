using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Update()
    {
        if (Input.GetMouseButton(1))
            anim.SetBool("Closed", true);
        else
            anim.SetBool("Closed", false);
    }
}
