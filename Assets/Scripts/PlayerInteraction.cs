using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    //Reference for interactable objects, also sets it to null by default.
    public GameObject currentInterObj = null;


    //The Update method for interacting with an object with space.
    private void Update()
    {
       if( Input.GetKeyDown(KeyCode.Space) && currentInterObj != null)
       {
            currentInterObj.GetComponent<InteractionObject>().Interact();

       }
    }

    //Method for staying within the trigger of interactable objects.
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("InterObject"))
        {
            currentInterObj = other.gameObject;
        }
        
    }

    //Method for leaving the trigger of the interactable object.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("InterObject"))
        {
            currentInterObj = null;
        }
        
    }
}
