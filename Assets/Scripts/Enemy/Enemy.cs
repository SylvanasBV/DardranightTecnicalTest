using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Status")]
    public float health; // Health of the enemy
    public float damage; // Damage of the enemy
    public float speed; // Speed of the enemy
    public int scorePoints; // Score given when the enemy is defeated


    protected Rigidbody rb; // Rigidbody of the enemy
    protected Animator anim; // Animator of the enemy
    protected Vector2 movementDirection; // Direction of the movement of the enemy

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();// Get the Rigidbody component
        anim = GetComponent<Animator>();// Get the Animator component
    }

    protected abstract void Move(); // To define the movement of the especific enemy

    public virtual void TakeDamage(float amount) // To take damage
    {
        health -= amount;
        if (health <= 0) Die(); // If the health is less than 0, die
    }

    protected virtual void Die() // To destroy the enemy
    {
        GameManager.instanceGameManager.AddScore(scorePoints);
        anim.SetBool("Dead", true); // Set the trigger of the die animation
    }

    public void OnDeathAnimationEnd()
    {
        Destroy(gameObject); // Se destruye el enemigo al final de la animación
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(10f); // Puedes ajustar el daño
        }
        else if (other.CompareTag("MapLimit"))
        {
            HandleMapCollision();
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instanceGameManager.TakeDamage(40); // Damage to the player
            Die(); // Die the enemy
        }
    }

    protected abstract void HandleMapCollision(); // To define comportament when the enemy collides with the map limits
}
