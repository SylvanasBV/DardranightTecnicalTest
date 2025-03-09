using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint; // Position of the fire point
    public float fireRate = 0.5f; // Rate of fire
    private float fireRateTimer; // Timer of the fire rate
    private Vector2 shootDirection = Vector2.right; // Direction of the bullet
 
    // Update is called once per frame
    private void Update()
    {
        HandledShooting();// Handle the shooting
        UpdateShootDirection(); // Update the direction of the bullet
    }

    void HandledShooting()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time >= fireRateTimer)// Verify if the player press the space key and the time is greater than the fire rate timer
        {
            Shoot(); // Shoot the bullet
            fireRateTimer = Time.time + fireRate; // Set the fire rate timer
        }
    }

    void Shoot()
    {
        GameObject bullet = BulletPool.BulletInstance.GetBullet(); // Get the bullet from the pool
        if (bullet != null && bullet.TryGetComponent(out Bullet bulletScript))
        {
            bullet.transform.position = firePoint.position;// Set the position of the bullet to shoot
            bulletScript.Activate(shootDirection); // Activet the function to move the bullet
        }
    }

    private void UpdateShootDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // Get the horizontal input
        if (horizontal != 0)
        {
            shootDirection = (horizontal > 0) ? Vector2.right : Vector2.left; // Set the direction of the bullet
        }
    }
}
