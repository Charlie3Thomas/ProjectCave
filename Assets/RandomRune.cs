using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRune : MonoBehaviour
{
    private Vector2 rn;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = this.gameObject.GetComponent<Renderer>().material;
        rn = new Vector2(Random.Range(0, 500), Random.Range(0, 500));
        Debug.Log(rn);
        mat.SetVector("_RandomSeed", rn);
    }
}
