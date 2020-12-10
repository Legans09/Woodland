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
    public float walkDelay = 2f;
    
    public BetterJump jumpControl;
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

    void FixedUpdate()
    {
        //Sounds~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //Control character walking sounds

        if (Input.GetButtonDown("Horizontal"))
        {
            FindObjectOfType<AudioManager>().PlayLoop("Walking");

        }
        if (Input.GetButtonUp("Horizontal"))
        {
            Invoke("stopWalking", walkDelay);
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


    //finish healing animation
    private void healStop()
    {
        characterAnimator.SetBool("Healing", false);
        healing = false;
    }

    //Finish walking sound
    private void stopWalking() {

        FindObjectOfType<AudioManager>().StopLoop("Walking");
        if (Input.GetButtonDown("Horizontal")) {
            FindObjectOfType<AudioManager>().PlayLoop("Walking");
        }
    }






}
