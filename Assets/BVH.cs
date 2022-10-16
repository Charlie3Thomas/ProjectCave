using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BVH : MonoBehaviour
{
    [SerializeField] private GameObject bvh_upper;
    [SerializeField] private GameObject bvh_lower;
    [SerializeField] private GameObject bvh_node;

    private Vector3 lower_bounds_pos;
    private Vector3 upper_bounds_pos;
    private Vector3 bounds_distance;

    private void OnEnable()
    {
        upper_bounds_pos = bvh_upper.transform.position;
        lower_bounds_pos = bvh_lower.transform.position;
    }

    private void Start()
    {
        bounds_distance = new Vector3(
            (upper_bounds_pos.x + lower_bounds_pos.x) / 2,
            (upper_bounds_pos.y + lower_bounds_pos.y) / 2,
            (upper_bounds_pos.z + lower_bounds_pos.z) / 2);

        int max_x = (int)(upper_bounds_pos.x / 20);
        int max_y = (int)(upper_bounds_pos.y / 20);
        int max_z = (int)(upper_bounds_pos.z / 20);

        for (int x = 0; x <= max_x; x++)
        {
            for (int y = 0; y <= max_x; y++)
            {
                for (int z = 0; z <= max_x; z++)
                {
                    Vector3 node_pos = new(x * 20, y * 20, z * 20);
                    GameObject node = Instantiate(bvh_node, node_pos, this.transform.rotation, this.transform);
                }
            }
        }

        //Debug.Log(bounds_distance);
    }



}
