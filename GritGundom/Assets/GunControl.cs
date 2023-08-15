using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    IGunBehavior gun1 = new SMGBehavior();
    IGunBehavior gun2 = new RifleBehavior();
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public GameObject altBulletPrefab; // Reference to the alt-fire bullet prefab
    public float fireSpeed = 20f;
    public float fireRate = 20f;     // How many bullets per second
    public float spreadAngle = 5f;  // Angle for the bullet spread
    public float altFireSpeed = 25f;
    public float altFireRate = 5f;
    public float altSpreadAngle = 2.5f;
    //public float altFireRicochetCount = 3;
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
            gun1.Fire(bulletPrefab, bulletSpawnPoint, spreadAngle, fireSpeed);
            timeSinceLastFire = 0f; // Reset timer
        }
        if (Input.GetMouseButton(1) && timeSinceLastFire > 1 / altFireRate) // Check if left mouse button is clicked
        {
            gun2.Fire(altBulletPrefab, bulletSpawnPoint, altSpreadAngle, altFireSpeed);
            timeSinceLastFire = 0f; // Reset timer
        }
    }

}
