using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogue;

    public GameObject dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue<string>();
        
    }

    //Adds sentences to the queue to the dialogue.
    public void StartDialogue(string[] sentences)
    {
        dialogue.Clear();

        dialogueUI.SetActive(true);
        
        Cursor.visible = true;

        foreach (string currentstring in sentences)
        {
            dialogue.Enqueue(currentstring);
        }

        //TODO: pass first item in dialogue<queue> into text box of dialogue panel.

        //foreach (string sentence in dialogue)
        //{
        //    Debug.Log(sentence);//Outputs sentence to console.
        //}

    }
    
    //Method for displaying the next box of text to the player.
    public void DisplayNextText()
    {
        if(dialogue.Count >= 1)
        {
            dialogue.Dequeue();
        }
        else
        {
            dialogue.Clear();
            dialogueUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method for disabling the UI.
    public void DisableDialogueUI()
    {
        dialogueUI.SetActive(false);
    }

}
