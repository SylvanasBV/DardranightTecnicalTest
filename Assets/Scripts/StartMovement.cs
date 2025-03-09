using UnityEngine;

public class StartMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the star
    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * speed * Time.deltaTime; // Move the star down
    }
}
