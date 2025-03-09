using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMedium : Enemy
{
    public Transform firePointUp,firePointDown; // Fire point of the enemy
    public GameObject bulletPrefab; // Bullet prefab
    public float fireRate = 1f; // Fire rate of the enemy
    public float zigzagWidth = 14f; // Width of the zigzag movement


    private float nextFire; // Time to
    private Transform player; // Player position
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Get the player position
        health = 50; // Set the health of the enemy
        damage = 20; // Set the damage of the enemy
        speed = 3; // Set the speed of the enemy
        scorePoints = 200; // Set the score points of the enemy
    }

    protected override void Move()
    {
        transform.position += new Vector3(0,Mathf.Sin(Time.time * speed)*zigzagWidth*Time.deltaTime,0); // Move the enemy to the Top and Down
    }

    protected override void HandleMapCollision()
    {
       //Didn't use at the moment
    }

    private void Update()
    {
        Move();//movement of the payer
        if (Time.time >= nextFire) // Verify if can shot in this moment
        {
            Shoot();// Shoot the bullet
            nextFire = Time.time + fireRate; // Calculate the next shoot
        }
    }

    private void Shoot()
    {
        if (player == null) return; //if can't found the player, leave the function

        float directionY = Mathf.Sign(player.position.y - firePointUp.position.y);// Verify if the ship is up or down

        GameObject bulletUp = Instantiate(bulletPrefab, firePointUp.position, Quaternion.Euler(new Vector3(0,0,90)));
        bulletUp.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, directionY * 3f);

        GameObject bulletDown = Instantiate(bulletPrefab, firePointDown.position, Quaternion.Euler(new Vector3(0, 0, 90)));
        bulletDown.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, directionY * 3f);
    }
}
