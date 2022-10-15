using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDecal : MonoBehaviour
{
    [SerializeField] private GameObject decal;
    private Vector3 random_window;
    private int total_decals;

    private void OnEnable()
    {
        if (decal == null)
        {
            Debug.LogError("No prefab assigned for decal");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //for (int y = -5; y < 5; y++)
            //{
            //    for(int x = -5; x < 5; x++)
            //    {
            //        Ray r = new Ray(transform.position, transform.forward + new Vector3(x, y, 0));
            //        RaycastHit hit_info;
            //        if (Physics.Raycast(r, out hit_info))
            //        {
            //            ////Debug.Log(hit_info.distance);
            //            if (hit_info.collider.gameObject.tag != "Decal"/* && hit_info.distance < 10.0f*/)
            //            {
            //                GameObject _decal = Instantiate(decal, hit_info.point, Quaternion.LookRotation(hit_info.normal * -1));
            //                total_decals++;
            //            }
            //            //Debug.Log(hit_info.collider.gameObject.tag);

            //        }
            //    }
            //}

            Ray r = new Ray(transform.position + (transform.forward * 1), transform.forward);
            RaycastHit hit_info;
            if (Physics.Raycast(r, out hit_info))
            {
                ////Debug.Log(hit_info.distance);
                if (hit_info.collider.gameObject.tag != "Decal"/* && hit_info.distance < 10.0f*/)
                {
                    GameObject _decal = Instantiate(decal, hit_info.point, Quaternion.LookRotation(hit_info.normal * -1));
                    total_decals++;
                }
                //Debug.Log(hit_info.collider.gameObject.tag);

            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log(total_decals);
        }

    }
}
