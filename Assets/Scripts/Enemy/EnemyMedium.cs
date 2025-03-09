using UnityEngine;

public class EnemyMedium : Enemy
{
    public Transform firePointUp,firePointDown; // Fire point of the enemy
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

    protected override void Shoot()
    {
        if (player == null) return; //if can't found the player, leave the function

        float directionY = Mathf.Sign(player.position.y - firePointUp.position.y);// Verify if the ship is up or down

        Vector2 velocity = new Vector2(-5f, directionY * 3f);

        FireBullet(firePointUp.position, velocity, 90);
        FireBullet(firePointDown.position, velocity, 90);
    }
}
