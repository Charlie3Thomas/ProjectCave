using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float m_sens_x;
    [SerializeField] private float m_sens_y;
    public Transform c_orientation;
    private float c_rotation_x;
    private float c_rotation_y;

    private void Start()
    {
        m_sens_x *= 10;
        m_sens_y *= 10;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (c_orientation == null)
        {
            Debug.LogError("Camera does not have a valid player Camera orientation reference");
        }
    }

    private void Update()
    {
        // Get mouse input
        float m_x = Input.GetAxis("Mouse X") * (Time.deltaTime * m_sens_x);
        float m_y = Input.GetAxis("Mouse Y") * (Time.deltaTime * m_sens_y);
        c_rotation_y += m_x;
        c_rotation_x -= m_y;
        c_rotation_x = Mathf.Clamp(c_rotation_x, -90.0f, 90.0f);

        // Rotate cam and orientation
        if (c_orientation != null)
        {
            transform.rotation = Quaternion.Euler(c_rotation_x, c_rotation_y, 0);
            c_orientation.rotation = Quaternion.Euler(0, c_rotation_y, 0);
        }
    }
}
