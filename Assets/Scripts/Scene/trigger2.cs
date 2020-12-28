using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger2 : MonoBehaviour
{

    public Dialogue dialogue;
   
    private bool isNext = false; 
    public bool triggered = false;
   


    public void setNext()
    {
     //   Debug.Log("trigger 2 is next");
        isNext = true;
        enabled = true;
    }


    private void Start()
    {
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!triggered && isNext)
        {
           // Debug.Log("Triggered!");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<trigger3>().setNext();
            FindObjectOfType<JumpController>().setJump(true);
            Invoke("enableJump", 7f);

            triggered = true;

        }


    }


     void enableJump()
    {

        FindObjectOfType<JumpController>().setJump(false);
    }

}
