using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGBehavior : MonoBehaviour, IGunBehavior
{
    public IGunBehavior.GunBehaviorType BehaviorType => IGunBehavior.GunBehaviorType.Automatic;

    public float fireSpeed = 20f;
    public float fireRate = 20f;     // How many bullets per second
    public float spreadAngle = 5f;  // Angle for the bullet spread
    public Transform bulletSpawnPoint; // Where the bullets will be spawned
    
    private float timeSinceLastFire;

    public void Start()
    {   
        timeSinceLastFire = 0f;
    }

    public void Update()
    {
        if (timeSinceLastFire < 1 / fireRate)
            timeSinceLastFire++;
    }

    public void Fire(GameObject bulletPrefab, Transform bulletSpawnPoint, float spreadAngle, float fireSpeed)
    {
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            IBulletBehavior bulletBehavior = bullet.GetComponent<IBulletBehavior>();
            bulletBehavior.bulletSpeed = fireSpeed;

            // Add randomness to the angle
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);
            Vector2 bulletDirection = Quaternion.Euler(0, 0, randomAngle) * bulletSpawnPoint.up;

            // Set the bullet's velocity in the direction the gun is facing, with added spread
            rb.velocity = bulletDirection * fireSpeed; // Adjust the speed as needed
            GameObject.Destroy(bullet, 5f);
        }
    }
}
