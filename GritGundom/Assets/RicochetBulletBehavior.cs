using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBulletBehavior : MonoBehaviour, IBulletBehavior
{
    public float bulletSpeed { get; set; }
    public float raycastDistance = 0.5f; // Distance of the raycast
    public int maxRicochets; // Number of times the bullet can ricochet
    private int currentRicochets = 0;

    private Rigidbody2D rb;
    Vector3 lastVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        //Bullet faces right direction
        lastVelocity = rb.velocity;
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle+90);

        //Maintain Constant Speed
        Vector2 normalizedVelocity = rb.velocity.normalized; // Normalize the velocity
        rb.velocity = normalizedVelocity * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        { 
            if (currentRicochets < maxRicochets)
            {
                var speed = lastVelocity.magnitude;
                var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
                rb.velocity = direction * Mathf.Max(speed, 0f);
                currentRicochets++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

