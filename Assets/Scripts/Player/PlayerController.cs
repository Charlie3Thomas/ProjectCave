using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float p_move_speed;

    public float p_friction;

    public float p_jump_strength;
    public float p_jump_cooldown;
    public float p_air_multiplier;
    bool p_can_jump;

    [HideInInspector] public float p_walk_speed;
    [HideInInspector] public float p_sprint_speed;

    [Header("Keybinds")]
    public KeyCode jump_key = KeyCode.Space;

    [Header("Ground Check")]
    public float p_height;
    public LayerMask what_is_ground;
    bool p_grounded;

    public Transform p_orientation;

    float m_input_horizontal;
    float m_input_vertical;

    Vector3 v3_move_direction;

    Rigidbody p_rb;

    private void Start()
    {
        p_rb = GetComponent<Rigidbody>();
        p_rb.freezeRotation = true;

        p_can_jump = true;
    }

    private void Update()
    {
        // ground check
        p_grounded = Physics.Raycast(transform.position, Vector3.down, p_height, what_is_ground);
        //Debug.Log(p_grounded);

        MyInput();
        SpeedControl();

        // handle drag
        if (p_grounded) { p_rb.drag = p_friction; }
        else { p_rb.drag = 0; }
            
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        m_input_horizontal = Input.GetAxisRaw("Horizontal");
        m_input_vertical = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jump_key) && p_can_jump && p_grounded)
        {
            //Debug.Log("Requesting Jump");
            p_can_jump = false;

            Jump();

            Invoke(nameof(ResetJump), p_jump_cooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        v3_move_direction = p_orientation.forward * m_input_vertical + p_orientation.right * m_input_horizontal;

        // on ground
        if (p_grounded)
            p_rb.AddForce(v3_move_direction.normalized * p_move_speed * 10f, ForceMode.Force);

        // in air
        else if (!p_grounded)
            p_rb.AddForce(v3_move_direction.normalized * p_move_speed * 10f * p_air_multiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 xz_velocity = new Vector3(p_rb.velocity.x, 0f, p_rb.velocity.z);

        // limit velocity if needed
        if (xz_velocity.magnitude > p_move_speed)
        {
            Vector3 p_limited_velocity = xz_velocity.normalized * p_move_speed;
            p_rb.velocity = new Vector3(p_limited_velocity.x, p_rb.velocity.y, p_limited_velocity.z);
        }
    }

    private void Jump()
    {
        // Debug.Log("Jumping!");
        // reset y velocity
        p_rb.velocity = new Vector3(p_rb.velocity.x, 0f, p_rb.velocity.z);

        p_rb.AddForce(transform.up * p_jump_strength, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        p_can_jump = true;
    }
}
