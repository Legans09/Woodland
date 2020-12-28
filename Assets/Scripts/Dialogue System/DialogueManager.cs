using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    public TMP_Text  nameText;
    public TMP_Text dialougueText;
    public diaBoxController diaboxPlayer;
    public diaBoxController diaboxNPC;
    public JumpController jumpControl;
    public PlayerMovement movement;
    public followPlayer1 camControl;
    private bool isRunning = false;
    

    public Animator animator;

    private Queue<string> sentences;

    void Start() {
        sentences = new Queue<string>();
        jumpControl = FindObjectOfType<JumpController>();
        movement = FindObjectOfType<PlayerMovement>();
        camControl = FindObjectOfType<followPlayer1>();
    
    }

    private void Update()
    {

        if (!isRunning)
        {
            if (Input.GetKeyDown("space"))
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        if (dialogue.name == "Player")
        {
            diaboxPlayer.setVisable(true);
        }
        else 
        {
            diaboxNPC.setVisable(true);
        }
        
        jumpControl.setDialogue(true);
        movement.setDialogue(true);
        camControl.setDialogue(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)

    {
        isRunning = true;
        dialougueText.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
            dialougueText.text += letter;
            yield return null;
        }

        isRunning = false;
    }


    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        diaboxPlayer.setVisable(false);
        diaboxNPC.setVisable(false);
      //  jumpControl.setDialogue(false);
        movement.setDialogue(false);
        camControl.setDialogue(false);
        Invoke("jumpDelay", 2f);

    }

    void jumpDelay() 
    {
        jumpControl.setDialogue(false);
      //  Debug.Log("Jump enabled!");
    }



}
