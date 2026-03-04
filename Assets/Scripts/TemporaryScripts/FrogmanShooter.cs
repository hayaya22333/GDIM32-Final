using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogmanShooter : MonoBehaviour
{
    enum SpreadType { Spin, Straight }

    [Header("Bullet Attributes")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int numberOfBullets = 3;

    [Header("Shooter Attributes")]
    public Transform firePoint;
    public float spreadAngle = 30f;
    private float timer = 0f;
    private float startAngle;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] private float rotateDirection = 1f;
    [SerializeField] private SpreadType spreadType;
    [SerializeField] private float offset = 0f;
    public float radius = 2f;

    private float timesFired;
    [SerializeField] private float maxFireCount;

    private Transform target;


    void Start()
    {
        startAngle = -spreadAngle / 2f + offset;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (spreadType == SpreadType.Spin)
        {
            startAngle = startAngle + 1;
        }

        if (spreadType == SpreadType.Straight)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            float angleRad = Mathf.Atan2(-directionToTarget.y, -directionToTarget.x);
            float angleDeg = angleRad * Mathf.Rad2Deg;
            startAngle = angleDeg - spreadAngle / 2;
        }

        if (timesFired < maxFireCount)
        {
            shoot();
        }
    }

    void shoot()
    {
        if (timer >= firingRate)
        {
            ShootSpread();
            timesFired += 1;
            timer = 0;
        }
    }


    void ShootSpread()
    {
        startAngle = startAngle + rotateDirection;
        float angleStep = spreadAngle / (numberOfBullets - 1);

        for (int i = 0; i < numberOfBullets; i++)
        {
            float currentAngle = startAngle + (i * angleStep);
            Quaternion rotation = Quaternion.Euler(0, 0, currentAngle);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

        }

    }
}
