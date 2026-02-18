using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody m_rigidbody;
    private Camera m_camera;

    public float moveSpeed = 6f;
    public float acceleration = 20f;

    void Awake()
    {
        this.m_rigidbody = GetComponent<Rigidbody>();
       // this.m_camera = Camera.main;
    }

    void Update()
    {
        
        



    }

    private void Inputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Vector3 input = new Vector3(x,0f,z);
        // Vector3 dir = Vector3.ClampMagnitude(input,1f);

        // if(dir!=Vector3.Zero)
        // {
        //     //this.m_rigidbody.linearVelocity += dir * moveSpeed;
        // }
    }

    private bool IsGrounded()
    {
        return true;
    }
}
