using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDecal : MonoBehaviour
{
    [SerializeField] private LayerMask ignored_mask;
    [SerializeField] private GameObject decal;
    [SerializeField] private float r_spreadfactor = 0.0f;
    private int total_decals;
    private float decal_rate = 0.25f;
    private float t = 0.0f;
    

    private void OnEnable()
    {
        

        if (decal == null)
        {
            Debug.LogError("No prefab assigned for decal");
        }
    }

    private void Update()
    {
        t += Time.deltaTime;
        //Debug.Log(t);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Decal(t);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log(total_decals);
        }

    }

    void Decal(float _t)
    {
        if (_t > decal_rate)
        {
            RaycastHit hit_info;
            Vector3 r_origin = transform.position + transform.forward;

            for (int i = 0; i < 10; i++)
            {

                Vector3 r_offset = new Vector3(
                    Random.RandomRange(-r_spreadfactor, r_spreadfactor),
                    Random.RandomRange(-r_spreadfactor, r_spreadfactor),
                    0);
                Vector3 r_offset_rotation = this.transform.rotation * r_offset;
                Vector3 r_direction = transform.forward + r_offset_rotation;

                Ray r = new Ray(r_origin, r_direction);
                if (Physics.Raycast(r, out hit_info, 10.0f, ~ignored_mask))
                {
                    GameObject _decal = Instantiate(decal, hit_info.point, Quaternion.LookRotation(hit_info.normal * -1));
                    total_decals++;
                }
            }            
        }        
    }
}
