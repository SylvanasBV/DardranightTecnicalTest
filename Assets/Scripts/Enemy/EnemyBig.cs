using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : Enemy
{
    public GameObject bulletPrefab; // Bullet prefab
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
        if(player == null) return; // If can't found the player, leave the function
        Vector3 direction = (player.position - transform.position).normalized; // Define the direction of the movement
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
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

    private void Shoot()
    {
        Vector2 direction = (player.position - transform.position).normalized; // Define the direction of the movement
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 90))); // Instantiate the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 5f; // Shoot to the player
    }
}
