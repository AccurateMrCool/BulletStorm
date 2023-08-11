using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGBulletBehavior : MonoBehaviour, IBulletBehavior
{
    public float bulletSpeed { get; set; }

    private Rigidbody2D rb; 

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
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle+90);
        //Maintain Constant Speed
        Vector2 normalizedVelocity = rb.velocity.normalized; // Normalize the velocity
        rb.velocity = normalizedVelocity * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            GameObject.Destroy(gameObject); // Destroy the bullet  
        }
    }
}
