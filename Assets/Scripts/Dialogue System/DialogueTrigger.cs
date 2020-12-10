using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
   
    public bool triggered = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!triggered)
        {
            Debug.Log("Triggered!");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
   
            triggered = true;

        }
        
        
    }

}
