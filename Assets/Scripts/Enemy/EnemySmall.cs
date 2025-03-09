using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : Enemy
{
    public float zigzagWidth = 3f; // Width of the zigzag movement
    public float fireRate = 2f; // Fire rate of the enemy
    public Transform firePoint; // Fire point of the enemy
    public GameObject bulletPrefab; // Bullet prefab

    private float nextFire; // Time to the next fire
    private bool movingRight = true; // To know the direction of the zigzag movement

    protected override void Move()
    {
        float moveDirection = movingRight ? speed*Time.deltaTime : -speed * Time.deltaTime; // Define the direction of the movement
        transform.position += new Vector3(moveDirection, Mathf.Sin(Time.time * speed) * zigzagWidth * Time.deltaTime); // Move the enemy with osilatory movement
    }

    protected override void HandleMapCollision()
    {
        movingRight = !movingRight; // Change the direction of the zigzag movement
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
        Vector2 direction = movingRight ? Vector2.left : Vector2.right;
        int rotation = movingRight ? 90 : -90;

        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0,rotation))// Instantiate the bullet
            .GetComponent<Rigidbody2D>().velocity = direction * 5f; // shoot to the left
    }
}
