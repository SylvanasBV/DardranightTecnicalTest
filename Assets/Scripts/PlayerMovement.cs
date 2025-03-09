using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player
    [SerializeField] private float getInputX = 0f; // Get the inputX of the player
    [SerializeField] private float getInputY = 0f; // Get the inputY of the player
    [SerializeReference] private Vector2 spawnRangeX = new Vector2(-8.70f, 8.70f); // Limit to spawn X 
    [SerializeReference] private Vector2 spawnRangeY = new Vector2(-3.90f, 6.50f); // Limit to spawn Y

    private Animator anim; // Animator of the player

    void Start()
    {
        anim = GetComponent<Animator>(); // Get the animator of the player
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();
        TransformMovement();
    }

    void UserInput()
    {
        getInputX = Input.GetAxis("Horizontal"); // Get the horizontal input of the player
        getInputY = Input.GetAxis("Vertical"); // Get the vertical input of the player
    }
    void TransformMovement()
    {
        Vector3 movePlayer = new Vector3(getInputX, getInputY, 0) * speed * Time.deltaTime; // Move the player With transform
        Vector3 newPosition = transform.position + movePlayer;// Set the new position of the player
        float MoveX = Mathf.Clamp(newPosition.x, spawnRangeX.x, spawnRangeX.y); // Limit the player to move in the X axis
        float MoveY = Mathf.Clamp(newPosition.y, spawnRangeY.x, spawnRangeY.y); // Limit the player to move in the Y axis
        transform.position = new Vector3(MoveX, MoveY, 0); // Set the position of the player with the limits
        
        if (anim != null)
        {
            anim.SetFloat("moveYFloat", getInputY); // Set the animation of the player
        }
    }
}
