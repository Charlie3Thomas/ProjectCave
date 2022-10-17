using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class BVHPlayerDistance : MonoBehaviour
{
    [SerializeField] private GameObject go_player;
    [SerializeField] private float t_updaterate = 1.0f;
    [SerializeField] public List<DecalSwitch> particle_list = new List<DecalSwitch>();
    private float t = 0.0f;
    public bool player_in_range;



    private void OnEnable()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
        if (go_player == null)
            Debug.LogError("There is no player object assigned to BVHPlayerDistance.cs");
    }

    private void FixedUpdate()
    {
        t += Time.deltaTime;
        if (t > t_updaterate)
        {
            PlayerInRange();

            if (particle_list.Count > 0)
            {
                //this.GetComponent<Collider>().enabled = PlayerInRange();
                if (player_in_range)
                {
                    foreach (DecalSwitch _ds in particle_list)
                    {
                        _ds.can_update = true;
                    }
                }
            }            
        }
    }

    private bool PlayerInRange()
    {
        float player_dist = (go_player.transform.position - this.transform.position).sqrMagnitude;
        if ( player_dist < 1200.0f)
        {
            player_in_range = true;
            return true;
        }
        player_in_range = false;

        if(player_dist > 3000 && player_dist < 4500)
        {
            t_updaterate = 5;
            return false;
        }
        else if (player_dist > 4500 && player_dist < 7500)
        {
            t_updaterate = 7;
            return false;
        }
        else if (player_dist > 7500)
        {
            t_updaterate = 10;
            return false;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        if (player_in_range)
        {
            Gizmos.DrawWireCube(this.transform.position, new Vector3(20, 20, 20));
        }
    }

}
