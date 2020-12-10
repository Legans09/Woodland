using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger4 : MonoBehaviour
{
    public Dialogue dialogue;
    public bool triggered = false;
    public bool isNext = false;
    public Transform npc;
    private bool faceLeft = false;
    public GameObject blocker;

    private Vector3 rotateLeft = new Vector3(0, -180, 0);
    private Vector3 rotateRight = new Vector3(0, 180, 0);


    
    public void setNext()
    {
        
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
            rotateNPC();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<Blocker>().setActive();
            triggered = true;
            Invoke("rotateNPC", 5f);
        }     
    }

    public void triggerDialogue() 
    {
        if (!triggered && isNext)
        {
            rotateNPC();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<Blocker>().setActive();
            triggered = true;
            Invoke("rotateNPC", 5f);
        }
    }


    public void rotateNPC() 
    {
        if (faceLeft == false)
        {

            npc.Rotate(rotateLeft);

            faceLeft = true;
        }
        else if (faceLeft == true)
        {
            npc.Rotate(rotateRight);
            faceLeft = false;
        }
    }
}
