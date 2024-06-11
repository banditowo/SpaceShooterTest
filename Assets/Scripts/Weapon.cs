using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletDelay;

    [SerializeField] private bool isFiring;

    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce = 20f;

    private float lastBulletTime;

    private void Update()
    {
        if (isFiring)
        {
            float timeSinceFire = Time.time - lastBulletTime;

            if (timeSinceFire >= bulletDelay)
            {
                Fire();
                lastBulletTime = Time.time;

            }
        }
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = bulletSpeed * firePoint.transform.up;

        /*Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = fireForce * transform.up;*/
    }

    private void OnFire(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
    }
}
