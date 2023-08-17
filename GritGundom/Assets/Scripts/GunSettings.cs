using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSettings : MonoBehaviour
{
    IGunBehavior gun;
    public GameObject gunPrefab;
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float fireSpeed = 20f;
    public float fireRate = 20f;     // How many bullets per second
    public float spreadAngle = 5f;  // Angle for the bullet spread
    public Transform bulletSpawnPoint; // Where the bullets will be spawned

    private float timeSinceLastFire = 0f; // Timer to keep track of fire rate

    private void Start()
    {
        gun = gunPrefab.GetComponent<IGunBehavior>();
        bulletSpawnPoint = transform.Find("BulletSpawnPoint");
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Adjust the offset based on your sprite's default orientation
        transform.rotation = Quaternion.Euler(0, 0, angle);

        timeSinceLastFire += Time.deltaTime; // Increment timer

        if (Input.GetMouseButton(0) && timeSinceLastFire > 1 / fireRate) // Check if left mouse button is clicked
        {
            gun.Fire(bulletPrefab, bulletSpawnPoint, spreadAngle, fireSpeed);
            //gun1.Update(bulletPrefab, bulletSpawnPoint, spreadAngle, fireSpeed, fireRate);
            timeSinceLastFire = 0f; // Reset timer
        }
    }
}
