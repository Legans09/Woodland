using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger3 : MonoBehaviour
{
    public Dialogue dialogue;
    public bool triggered = false;
    public bool isNext = true;

    public void setNext()
    {
        Debug.Log("trigger 3 is next");
        isNext = true;
        enabled = true;
    }


    private void Start()
    {
        this.enabled = false;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!triggered && isNext)
        {
           // Debug.Log("Triggered!");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<trigger4>().setNext();

            triggered = true;

        }

      

    }

  
}
