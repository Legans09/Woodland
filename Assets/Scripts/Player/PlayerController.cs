using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    
    public Transform player;
    public bool left = false;

    public Animator characterAnimator;
    public Animator slashAnimator;
    public GameObject slash;
    private Rigidbody2D rb2d;
    public float walkDelay = 1.6f;
    
    public JumpController jumpControl;
    public AttackController attackControl;

    public bool attacking=false;
    public bool jumping=false;
    public bool healing =false;
    public float attackDuration;
    public float healDuration;
    public PlayerMovement movement;

   
  

    
    private void Awake()
    {
        attackControl = FindObjectOfType<AttackController>();
        rb2d = GetComponent<Rigidbody2D>();
        
       
    }

    void Update()
    {
        //Sounds~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //Control character walking sounds
            
        if (Input.GetButtonDown("Horizontal"))
        {
            if (movement.getAcceleration() > 1f)
            {
                FindObjectOfType<AudioManager>().Play("FastWalking");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("Walking");
            }        
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            // Invoke("stopWalking", walkDelay);
            FindObjectOfType<AudioManager>().Stop("Walking");
            FindObjectOfType<AudioManager>().Stop("FastWalking");
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

     
        // Lunch attack
        if (Input.GetKeyUp("e"))
        {

            attackControl.attack();

        }
        // Lunch healing animation
        if (Input.GetKeyUp("h"))
        {
            
            healing = true;

            characterAnimator.SetBool("Healing", true);

            Invoke("healStop", healDuration);

        }
    }

    internal void setJumping(bool isJumping)
    {
        jumping = isJumping;
    }


    //finish healing animation
    private void healStop()
    {
        characterAnimator.SetBool("Healing", false);
        healing = false;
    }

    //Finish walking sound
    private void stopWalking() {

        FindObjectOfType<AudioManager>().Stop("Walking");
        
    }






}
