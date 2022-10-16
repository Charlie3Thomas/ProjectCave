using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DecalParent : MonoBehaviour
{
    private bool mr_enabled = true;
    private bool last_update = true;
    private GameObject go_player;
    private float t;
    private float t_updaterate;

    private void Update()
    {
        //this.GetComponent<MeshRenderer>().enabled = (go_player.transform.position - this.transform.position).sqrMagnitude < 300.0f;

        t += Time.deltaTime;
        if (t > 0.5)
        {
            this.GetComponent<MeshRenderer>().enabled = (go_player.transform.position - this.transform.position).sqrMagnitude < 1000.0f;
            t = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mr_enabled = !mr_enabled;
        }

        if (last_update != mr_enabled)
        {
            this.GetComponent<MeshRenderer>().enabled = mr_enabled;

        }
        last_update = mr_enabled;



    }
    private void OnEnable()
    {
        this.transform.parent = GameObject.FindGameObjectWithTag("GameController").transform;
        go_player = GameObject.FindGameObjectWithTag("Player");
    }
}
