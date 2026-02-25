using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{

    private Rigidbody m_rigidbody;
    private Camera m_camera;

    public float moveSpeed = 6f;
    public float jumpForce = 10f;

    public float mouseSensitivity = 1f;

    [SerializeField] private float pitchMin = -80f;
    [SerializeField] private float pitchMax = 80f;

    [SerializeField] private Transform feet;          
    [SerializeField] private float radius = 0.25f;    
    [SerializeField] private float distance = 0.1f;  
    [SerializeField] private LayerMask groundMask;

    private bool onGround = true;


    void Awake()
    {
        this.m_rigidbody = GetComponent<Rigidbody>();
        this.m_camera = Camera.main;
    }

    void Update()
    {

        Inputs();


    }

    private void Inputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        float mx = Input.GetAxisRaw("Mouse X");
        float my = Input.GetAxisRaw("Mouse Y");

        float yaw = mx * mouseSensitivity;
        float zaw = my * mouseSensitivity;

        RotatePlayer(yaw);
        MovePlayer(x, z);

        RotateCamera(zaw);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

    }


    private void RotatePlayer(float yaw)
    {
        m_rigidbody.MoveRotation(m_rigidbody.rotation * Quaternion.Euler(0f, yaw, 0f));
    }
    private void MovePlayer(float z, float x)
    {
        Vector3 v = (m_rigidbody.transform.forward * x + m_rigidbody.transform.right * z) * moveSpeed;
        m_rigidbody.velocity = new Vector3(v.x, m_rigidbody.velocity.y, v.z);
    }
    private void Jump()
    {
        if (IsGrounded())
            m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, m_rigidbody.velocity.y + jumpForce, m_rigidbody.velocity.z);
    }
    private void RotateCamera(float zaw)
    {
        Vector3 e = m_camera.transform.localEulerAngles;
        if (e.x > 180f) e.x -= 360f;
        e.x = Mathf.Clamp(e.x - zaw, pitchMin, pitchMax);
        m_camera.transform.localRotation = Quaternion.Euler(e.x, 0f, 0f);
    }

    public bool IsGrounded()
    {
        Vector3 p = feet ? feet.position : transform.position;
        Debug.Log(Physics.CheckSphere(p, radius, groundMask, QueryTriggerInteraction.Ignore));
        return Physics.CheckSphere(p, radius, groundMask, QueryTriggerInteraction.Ignore);
    }

}
