using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DisableMeshRender : MonoBehaviour
{
    [SerializeField] private Material m_vis;
    [SerializeField] private Material m_invis;


    // Start is called before the first frame update
    void Start()
    {
        if (Application.isPlaying)
        {
            this.GetComponent<Renderer>().material = m_invis;
        }
        else
        {
            this.GetComponent<Renderer>().material = m_vis;
        }
    }
}
