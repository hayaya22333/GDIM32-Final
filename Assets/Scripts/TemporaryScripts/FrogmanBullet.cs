using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanBullet : MonoBehaviour
{
    public float bulletDuration = 1f;
    public float speed = 20f;
    private float timer = 0f;
    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > bulletDuration)
            Destroy(this.gameObject);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            destroyProjectile();
            Debug.Log("hit player");
        }
    }

    private void destroyProjectile()
    {
        Destroy(gameObject);
    }
}
