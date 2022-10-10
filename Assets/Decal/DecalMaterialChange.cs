using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class DecalMaterialChange : MonoBehaviour
{
    [SerializeField] private Material m_close;
    [SerializeField] private Material m_far;
    [SerializeField] private Collider p_collider;

    private void OnEnable()
    {
        p_collider = GameObject.FindGameObjectWithTag("Player").GetComponent<SphereCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        this.GetComponent<DecalProjector>().material = m_close;        
    }

    private void OnTriggerExit(Collider p_collider)
    {
        this.GetComponent<DecalProjector>().material = m_far;
    }
}
