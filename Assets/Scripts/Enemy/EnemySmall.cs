using UnityEngine;

public class EnemySmall : Enemy
{
    public float zigzagWidth = 5f; // Width of the zigzag movement
    public float fireRate = 1f; // Fire rate of the enemy
    public Transform firePoint; // Fire point of the enemy
    public GameObject bulletPrefab; // Bullet prefab

    private float nextFire; // Time to the next fire
    private bool movingRight = false; // To know the direction of the zigzag movement

    public void Start()
    {
        health = 20; // Set the health of the enemy
        damage = 10; // Set the damage of the enemy
        speed = 5; // Set the speed of the enemy
        scorePoints = 100; // Set the score points of the enemy
    }
    protected override void Move()
    {
        float moveDirection = movingRight ? speed*Time.deltaTime : -speed * Time.deltaTime; // Define the direction of the movement
        transform.position += new Vector3(moveDirection, Mathf.Sin(Time.time * speed) * zigzagWidth * Time.deltaTime); // Move the enemy with osilatory movement
    }

    protected override void HandleMapCollision()
    {
        movingRight = !movingRight; // Change the direction of the zigzag movement
        if (speed <= 10) speed += 1; // Increment the speed of the enemy
    }
    private void Update()
    {
        Move(); // Move the enemy
        if (Time.time > nextFire) // If the time is greater than the next fire
        {
            Shoot(); // Shoot
            nextFire = Time.time + fireRate; // Update the next fire
        }
    }

    private void Shoot()
    {
        Vector2 direction = movingRight ? Vector2.right: Vector2.left; // Define the direction of the bullet
        int rotation = movingRight ? -90 : 90; // Define the rotation of the bullet

        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0,rotation),this.transform)// Instantiate the bullet
            .GetComponent<Rigidbody2D>().velocity = direction * 5f; // shoot to the left
    }
}
