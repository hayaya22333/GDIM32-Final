using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanBullet : MonoBehaviour
{
    public float bulletDuration = 1f;

    public float rotation = 0f;
    public float speed = 1f;

    private Vector3 spawnPoint;
    private float timer = 0f;

    [SerializeField] private Transform target;


    private void Start()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > bulletDuration)
            Destroy(this.gameObject);

        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x = -timer * speed * transform.right.x;
        float y = -timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            destroyProjectile();
        }
    }

    private void destroyProjectile()
    {
        Destroy(gameObject);
    }
}
