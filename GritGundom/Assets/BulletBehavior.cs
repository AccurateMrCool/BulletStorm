using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Optional: You can check the tag of the collided object if you want to filter specific collisions
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the bullet  
        }
    }
}
