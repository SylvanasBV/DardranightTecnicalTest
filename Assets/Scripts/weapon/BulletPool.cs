using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool BulletInstance { get; private set; } //Intance a Singleton
    public GameObject bulletPrefab; // Prefab of the bullet
    public int poolSize = 10; // Number of bullets

    private List<GameObject> bulletPool = new List<GameObject>(); // Pool of bullets

    private void Awake()
    {
        // Configurate the singleton
        if (BulletInstance == null)
        {
            // Set the singleton
            BulletInstance = this;
        }
        else
        {
            // Destroy the game object if there is another instance
            Destroy(gameObject);
            return;
        }

        // Create the pool of bullets
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }


    public GameObject GetBullet()
    {
        foreach (var bullet in bulletPool)// Verify if there is a bullet in the pool
        {
            // Get the bullet from the pool
            if (!bullet.activeInHierarchy)// Verify if the bullet is unActive
            {
                bullet.SetActive(false);// Deactivate the bullet
                return bullet;// Return the bullet

            }
        }

        GameObject newBullet = Instantiate(bulletPrefab);// Create a new bullet
        bulletPool.Add(newBullet);// Add the bullet to the pool
        return newBullet;// Return the bullet
    }

    // Method to returns to the original state of the bullet to the pool
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false); // Deactivate the bullet
    }
}
