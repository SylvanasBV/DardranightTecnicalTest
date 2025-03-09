using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Status")]
    public float health; // Health of the enemy
    public float damage; // Damage of the enemy
    public float speed; // Damage of the enemy
    public int scorePoints; // Score given when the enemy is defeated


    protected Rigidbody rb; // Rigidbody of the enemy
    protected Vector2 movementDirection; // Direction of the movement of the enemy

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();// Get the Rigidbody component
    }

    protected abstract void Move(); // To define the movement of the especific enemy

    public virtual void TakeDamage(float amount) // To take damage
    {
        health -= amount;
        if (health <= 0) Die();
    }

    protected virtual void Die() // To destroy the enemy
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(10f); // Puedes ajustar el daño
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("MapLimit"))
        {
            Debug.Log("Map Limit");
            HandleMapCollision();
        }
    }

    protected abstract void HandleMapCollision(); // To define comportament when the enemy collides with the map limits
}
