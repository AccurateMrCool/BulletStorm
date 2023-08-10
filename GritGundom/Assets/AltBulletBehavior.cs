using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltBulletBehavior : MonoBehaviour
{
    public float bulletSpeed;
    public float raycastDistance = 0.5f; // Distance of the raycast
    public int maxRicochets = 3; // Number of times the bullet can ricochet
    private int currentRicochets = 0;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rb.velocity.normalized, raycastDistance);

        if (hit.collider != null && hit.collider.tag != "Player")
        {
            Debug.Log("Hit something: " + hit.collider.name); // Print the name of the object that was hit

            if (currentRicochets < maxRicochets)
            {
                Vector2 inDirection = rb.velocity.normalized;
                Vector2 newDirection = Vector2.Reflect(inDirection, hit.normal).normalized; // Ensure it's normalized
                rb.velocity = newDirection * bulletSpeed; // Use the original bullet speed

                currentRicochets++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
