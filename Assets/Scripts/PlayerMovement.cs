using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
   
    //Variable for the move direction.
    private Vector3 moveDirection = Vector3.zero;

    //Reference to the Rigidbody.
    Rigidbody2D rigidBody;

    //Float move speed variable.
    public float moveSpeed = 2.0f;

    //Subscribes the HandleInput method to the action on awake.
    void Awake()
    {
        Actions.MoveEvent += HandleInput;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement(moveDirection);
    }

    //Method for the player movement.
    void HandlePlayerMovement(Vector2 moveDirection)
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    //Method for handling the input.
    void HandleInput(Vector2 input)
    {
        moveDirection = input;
    }

    //OnDisable Method for unsubscribing to the event.
    void OnDisable()
    {
        Actions.MoveEvent -= HandleInput;
    }
}
