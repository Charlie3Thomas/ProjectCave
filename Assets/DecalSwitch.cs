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
            //this.GetComponent<MeshRenderer>().enabled = 
            //    (go_player.transform.position - this.transform.position).sqrMagnitude < 1000.0f;

            if ((go_player.transform.position - this.transform.position).sqrMagnitude > 1000.0f)
            {
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
    }

    private GameObject NewDecal()
    {
        GameObject _decal;
        _decal = Instantiate(go_decal, this.transform.position, this.transform.rotation);
        _decal.transform.parent = this.transform;
        return _decal;
    }

    private void OnEnable()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
        go_parent = GameObject.FindGameObjectWithTag("GameController");
        this.transform.parent = go_parent.transform;
        decal = NewDecal();
    }

}
