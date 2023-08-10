using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public GameObject altBulletPrefab; // Reference to the alt-fire bullet prefab
    public float fireSpeed = 10f;
    public float fireRate = 1f;     // How many bullets per second
    public float spreadAngle = 5f;  // Angle for the bullet spread
    public float altFireSpeed = 10f;
    public float altFireRate = .33f;
    public float altFireRicochetCount = 3;
    public Transform bulletSpawnPoint; // Where the bullets will be spawned

    private float timeSinceLastFire = 0f; // Timer to keep track of fire rate

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Adjust the offset based on your sprite's default orientation
        transform.rotation = Quaternion.Euler(0, 0, angle);

        timeSinceLastFire += Time.deltaTime; // Increment timer

        if (Input.GetMouseButton(0) && timeSinceLastFire > 1 / fireRate) // Check if left mouse button is clicked
        {
            FireBullet();
            timeSinceLastFire = 0f; // Reset timer
        }
        if (Input.GetMouseButton(1) && timeSinceLastFire > 1 / altFireRate) // Check if left mouse button is clicked
        {
            AltFireBullet();
            timeSinceLastFire = 0f; // Reset timer
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Add randomness to the angle
        float randomAngle = Random.Range(-spreadAngle, spreadAngle);
        Vector2 bulletDirection = Quaternion.Euler(0, 0, randomAngle) * bulletSpawnPoint.up;

        // Set the bullet's velocity in the direction the gun is facing, with added spread
        rb.velocity = bulletDirection * fireSpeed; // Adjust the speed as needed
    }

    void AltFireBullet()
    {
        GameObject bullet = Instantiate(altBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        AltBulletBehavior altBehavior = bullet.GetComponent<AltBulletBehavior>();
        altBehavior.bulletSpeed = altFireSpeed; // Set the speed

        Vector2 bulletDirection = bulletSpawnPoint.up;
        rb.velocity = bulletDirection * altFireSpeed;

    }
}
