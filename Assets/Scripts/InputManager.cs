using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, PlayerController.IPlayerActions
{
    //Reference for the player controller.
    private PlayerController playerController;
    
    //Enabling the player controller on awake.
    void Awake()
    {
        playerController = new PlayerController();

        playerController.Player.Enable();

        playerController.Player.SetCallbacks(this);
    }

    //Method for printing movement direction to console and invoking the movement.
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Receiving move input : " + context.ReadValue<Vector2>());
        Actions.MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method for invoking the start and canceled interact actions.
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Actions.StartInteractEvent?.Invoke();
        }

        if (context.canceled)
        {
            Actions.CanceledInteractEvent?.Invoke();
        }
    }
}

//Class for all the actions.
public class Actions
{
    public static Action<Vector2> MoveEvent;
    public static Action StartInteractEvent;
    public static Action CanceledInteractEvent;
    
}
