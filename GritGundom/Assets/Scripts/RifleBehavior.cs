using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBehavior : MonoBehaviour, IGunBehavior
{
    public IGunBehavior.GunBehaviorType BehaviorType => IGunBehavior.GunBehaviorType.Automatic;

    public float fireSpeed = 25f;
    public float fireRate = 5f;     // How many bullets per second
    public float spreadAngle = 1f;  // Angle for the bullet spread
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
        GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        IBulletBehavior bulletBehavior = bullet.GetComponent<IBulletBehavior>();
        bulletBehavior.bulletSpeed = fireSpeed; // Set the speed
        //bulletBehavior.maxRicochets = fireRicochetCount;

        // Add randomness to the angle
        float randomAngle = Random.Range(-spreadAngle, spreadAngle);
        Vector2 bulletDirection = Quaternion.Euler(0, 0, randomAngle) * bulletSpawnPoint.up;

        rb.velocity = bulletDirection * fireSpeed;
        GameObject.Destroy(bullet, 5f);
    }
}
