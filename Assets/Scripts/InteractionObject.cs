using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    

    //Enum for all the possible player interactons with objects.
    public enum InteractionType
    {
        Nothing,
        Pickup,
        Info,
        Dialogue
    }

    //Reference to dialogue manager script.
    private DialogueManager dialogueManager;

    [Header("Type of Interactable")]
    public InteractionType interType;//Drop down for the enums above.


    [Header("Simple info message")]
    public string infoMessage;//Reference to a string from info text.
    public TMP_Text infoText;

    [Header("Dialogue Text")]
    [TextArea] public string[] sentences;//String for the dialogue of the Gnome.




    private void Awake()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    //Interact method for pressing space to interact with an object.
    public void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);
    
        //A switch state for all the interaction types.
        switch(interType)
        {
            case InteractionType.Nothing:
            {
                    Nothing();
                    break;  
            }
            case InteractionType.Pickup:
            {
                    Pickup();
                    break;
            }
            case InteractionType.Info:
            {
                    Info();
                    break;
            }
            case InteractionType.Dialogue:
            {
                    Dialogue();
                    break;
            }

        }
    
    }

    public void Nothing()
    {
        Debug.Log("Interaction type not defined");
    }

    public void Pickup()
    {
        Debug.Log("Added to inventory!:" + gameObject.name);
        gameObject.SetActive(false);
    }

    public void Info()
    {
        Debug.Log("Info Message:" + infoMessage);
        infoText.text = infoMessage;
    }

    public void Dialogue()
    {
        dialogueManager.StartDialogue(sentences);
    }

   
}
