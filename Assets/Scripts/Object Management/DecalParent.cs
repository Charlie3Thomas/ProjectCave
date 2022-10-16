using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DecalParent : MonoBehaviour
{
    [SerializeField] private float t_updaterate = 1.0f;
    private GameObject go_player;
    private GameObject go_parent;
    private float t;

    private void Update()
    {
        t += Time.deltaTime;
        RenderState();
    }

    private void RenderState()
    {
        if (t > t_updaterate)
        {
            this.GetComponent<MeshRenderer>().enabled = (go_player.transform.position - this.transform.position).sqrMagnitude < 1000.0f;
            t = 0.0f;
        }
    }

    private void OnEnable()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
        go_parent = GameObject.FindGameObjectWithTag("GameController");
        this.transform.parent = go_parent.transform;
    }
}
