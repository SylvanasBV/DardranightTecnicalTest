using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int defaultDamage = 10; // Default damage of the bullet
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int damage = GetDamageFromEnemy();
            GameManager.instanceGameManager.TakeDamage(10); //Damage to the player
            Destroy(gameObject); // be destroyed when it touches the player
        }
        else if (other.CompareTag("MapLimit"))
        {
            Destroy(gameObject); // be destroyed when it touches the map limit
        }
    }

    private int GetDamageFromEnemy()
    {
        Enemy enemy = GetComponentInParent<Enemy>();
        return enemy != null ? (int)enemy.damage : defaultDamage;
    }
}
