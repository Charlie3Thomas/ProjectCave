using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DecalSwitch : MonoBehaviour
{
    [SerializeField] private float t_updaterate = 1.0f;
    [SerializeField] private GameObject go_decal;
    private GameObject decal;
    private GameObject go_player;
    private GameObject go_parent;
    [SerializeField] private GameObject bvh_object;
    private GameObject[] bvh_objects;
    private float t;
    public bool can_update = true;

    private void OnEnable()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
        go_parent = GameObject.FindGameObjectWithTag("GameController");        

        this.transform.parent = go_parent.transform;
        decal = NewDecal();
    }

    private void Start()
    {
        bvh_objects = GameObject.FindGameObjectsWithTag("BVH");
        float this_distance;
        float closest_bvh = 0.0f;
        bool first_loop = true;
        foreach (GameObject _o in bvh_objects)
        {
            this_distance = (_o.transform.position - this.transform.position).sqrMagnitude;
            if (first_loop) 
            {
                first_loop = false;
                closest_bvh = this_distance; 
            }
            if (this_distance < closest_bvh)
            {
                //Debug.Log("HELLO");
                closest_bvh = this_distance;
                bvh_object = _o;
            }
        }

        if (bvh_object != null)
            bvh_object.GetComponent<BVHPlayerDistance>().particle_list.Add(this);
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (can_update && t > t_updaterate)
        {
            RenderState();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "BVH")
    //    {
    //        can_update = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "BVH")
    //    {
    //        Debug.Log("Switch left active BVH");
    //        can_update = false;
    //    }
    //}

    public void SetUpdateStatus(bool _b)
    {
        can_update = _b;
    }

    private void RenderState()
    {
        if ((go_player.transform.position - this.transform.position).sqrMagnitude > 1000.0f)
        {
            can_update = false;
            Destroy(decal);
        }
        else
        {
            if (decal == null)
            {
                decal = NewDecal();
            }
        }

        t = 0.0f;
    }

    private GameObject NewDecal()
    {
        GameObject _decal;
        _decal = Instantiate(go_decal, this.transform.position, this.transform.rotation);
        _decal.transform.parent = this.transform;


        return _decal;
    }

}
