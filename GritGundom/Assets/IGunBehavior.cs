using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunBehavior
{
    void Fire(GameObject bulletPrefab, Transform bulletSpawnPoint, float spreadAngle, float fireSpeed);
}

public class SMGBehavior : IGunBehavior
{
    public void Fire(GameObject bulletPrefab, Transform bulletSpawnPoint, float spreadAngle, float fireSpeed)
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

public class RifleBehavior : IGunBehavior
{
    public void Fire(GameObject bulletPrefab, Transform bulletSpawnPoint, float spreadAngle, float fireSpeed)
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        IBulletBehavior bulletBehavior = bullet.GetComponent<IBulletBehavior>();
        bulletBehavior.bulletSpeed = fireSpeed; // Set the speed
        //bulletBehavior.maxRicochets = fireRicochetCount;
        Debug.Log(bulletBehavior.bulletSpeed);

        // Add randomness to the angle
        float randomAngle = Random.Range(-spreadAngle, spreadAngle);
        Vector2 bulletDirection = Quaternion.Euler(0, 0, randomAngle) * bulletSpawnPoint.up;

        rb.velocity = bulletDirection * fireSpeed;
        GameObject.Destroy(bullet, 5f);
    }
}


