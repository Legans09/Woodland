using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger1 : MonoBehaviour
{

    public Dialogue dialogue;
    public bool triggered = false;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!triggered)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<trigger2>().setNext();

            triggered = true;

        }


    }


}
