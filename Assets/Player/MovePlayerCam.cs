using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerCam : MonoBehaviour
{
    [SerializeField] private Transform camera_position;

    private void Start()
    {
        if (camera_position == null)
        {
            Debug.LogError("Camera does not have a valid player Camera position reference");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (camera_position != null)
        {
            transform.position = camera_position.position;
        }
    }
}
