using UnityEngine;

public class EnemyBig : Enemy
{
    public Transform firePoint; // Fire point of the enemy
    public float fireRate = 1f; // Fire rate of the enemy
    private float nextFire; // Time to the next fire
    private Transform player; // Player position


    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Get the player position
        health = 100; // Set the health of the enemy
        damage = 30; // Set the damage of the enemy
        speed = 2; // Set the speed of the enemy
        scorePoints = 300; // Set the score points of the enemy
    }

    protected override void Move()
    {
        /*if(player == null) return; // If can't found the player, leave the function
        Vector3 direction = (player.position - transform.position).normalized; // Define the direction of the movement
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);*/
        Vector2 direction = (player.position - transform.position).normalized;// Define the direction of the movement
        transform.position += (Vector3)direction * speed * Time.deltaTime; // Movimiento sin Rigidbody2D
    }

    protected override void HandleMapCollision()
    {
        //Didn't use at the moment
    }

    private void Update()
    {
        Move(); // Move the enemy
        if (Time.time >= nextFire && player != null) // Verify if can shot in this moment
        {
            Shoot(); // Shoot the bullet
            nextFire = Time.time + fireRate; // Calculate the next shoot
        }
    }

    protected override void Shoot()
    {
        Vector2 direction = (player.position - transform.position).normalized; // Define the direction of the movement
        float directionX = Mathf.Sign(player.position.x - transform.position.x);// Verify if the ship is left or rigth
        int angle = directionX > 0 ? -90 : 90; // Define the rotation of the bullet
        FireBullet(firePoint.position, direction * 5f, angle);
    }
}
