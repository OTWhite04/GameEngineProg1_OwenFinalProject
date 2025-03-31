using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
   
    //Variable for the move direction.
    private Vector3 moveDirection = Vector3.zero;
    //Reference to the animator.
    public Animator animator;

    public float Magnitude;

    //Reference to the Rigidbody.
    Rigidbody2D rigidBody;

    //Method for handling the verical and horizontal movement animations for the player.
    private void HandleAnimation()
    {
       
        if(moveDirection.magnitude != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

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
        HandleAnimation();
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
