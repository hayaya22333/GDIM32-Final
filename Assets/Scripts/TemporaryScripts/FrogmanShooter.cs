using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrogmanShooter : MonoBehaviour
{
    public Transform[] shooterHead;
    public Transform[] firePoint;
    public GameObject projectilePrefab;
    public float rotationSpeed = 5f;
    public float fireRate = 1f;
    public float shootForce = 20f;
    public Transform target;
    private float shootDelay = 0f;
    private int timesFired;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        LookAtTarget();

        shootDelay += Time.deltaTime;
        if (shootDelay >= 1f / fireRate)
        {
            StartCoroutine(Shoot());
            shootDelay = 0f;
        }

        if(timesFired > 1)
        {
            gameObject.SetActive(false);
            timesFired = 0;
        }
    }

    private void LookAtTarget()
    {
        for(int i = 0; i < shooterHead.Length; i++)
        {
            Vector3 direction = target.position - shooterHead[i].position;
            Vector3 lookDirection = direction.normalized;
            Debug.DrawRay(transform.position, lookDirection * 10f, Color.red);

            Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
            Vector3 rotation = Quaternion.Lerp(shooterHead[i].rotation, lookRotation, rotationSpeed * Time.deltaTime).eulerAngles;
            shooterHead[i].rotation = Quaternion.Euler(rotation);
        }
        
    }

    private IEnumerator Shoot()
    {
        for (int i = 0; i < firePoint.Length; i++)
        {
            GameObject bulletInstance = Instantiate(projectilePrefab, firePoint[i].position, firePoint[i].rotation);
            FrogmanBullet bullet = bulletInstance.GetComponent<FrogmanBullet>();
            bullet.Move(firePoint[i].forward);
            yield return new WaitForSeconds(0.2f);
        }
        timesFired += 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, target.position);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
}
