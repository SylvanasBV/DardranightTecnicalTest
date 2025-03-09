using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Enemy shooter; // Enemy that shoots the bullet
    private int damage; // Damage of the bullet
    public void SetShooter (Enemy enemy, int bulletDamage)
    {
        shooter = enemy;
        damage = bulletDamage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instanceGameManager.TakeDamage(damage); //Damage to the player
            Destroy(gameObject); // be destroyed when it touches the player
        }
        else if (other.CompareTag("MapLimit"))
        {
            Destroy(gameObject); // be destroyed when it touches the map limit
        }
    }

}
