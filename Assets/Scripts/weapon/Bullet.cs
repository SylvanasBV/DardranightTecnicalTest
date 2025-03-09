using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // speed of the bullet
    [SerializeField]private Vector2 direction; // direction of the bullet
    [SerializeField]private Vector2 velocity; // velocity of the bullet

    private float lifeTime = 2f; // time before the bullet is destroyed

    public void Activate(Vector2 direction)
    {
        this.direction = direction.normalized;// set the direction of the bullet
        gameObject.SetActive(true);// set the bullet to active
        StartCoroutine(DeactivateAfterTime(lifeTime));// call the deactivate method after the lifetime
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;// calculate the velocity of the bullet
    }

    private void FixedUpdate()
    {
        if (!gameObject.activeSelf) return; // if bullet is active, don't do anything
        transform.position += (Vector3)velocity * Time.fixedDeltaTime;// move the bullet
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("MapLimit")) // verify if collide with Enemy or MapLimit
        {
            Deactivate(); // Deactivate the bullet
        }
    }

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);// Take the tame to deactivate
        Deactivate();// Deactivate the bullet
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);// Deactivate the bullet
    }


}
