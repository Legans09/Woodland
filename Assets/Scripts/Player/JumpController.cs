using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float delayLanding;
    public Animator characterAnimator;
    private bool jumping = false;
    private bool grounded = true;
    private bool diableJump = false;
    
    private bool dialogue = false;

    public trailSmokeController trail;
    


    public LayerMask groundLayers;

    [Range(0, 1)]
    public float jumpDuration;

    Rigidbody2D rb;

    [Range(0, 50)]
    public float jumpVelocity;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponentInChildren<Animator>();
        trail = FindObjectOfType<trailSmokeController>();

    }

    void  Update()    
    {

        if (rb.velocity.y < -0.1)
        {

            characterAnimator.SetBool("falling", true);


        }

        if (rb.velocity.y < -0.1)
        {

            characterAnimator.SetBool("falling", true);


        }
        else 
        {
            characterAnimator.SetBool("falling", false);

        }


        if (diableJump)
        {

            return;
        }

        if (Input.GetButton("Jump") && !jumping  && grounded && !dialogue )
        {
            jumping = true;
            grounded = false;
            trail.setGrounded(false);
            characterAnimator.SetBool("jumping", jumping);
            FindObjectOfType<AudioManager>().Play("Jump");

            rb.AddForce(new Vector2(0, 5 *jumpVelocity), ForceMode2D.Impulse);

            Invoke("jumpEnd", jumpDuration);
            Invoke("landing", jumpDuration + delayLanding);


        }
        

        if (rb.velocity.y < 0)
        {
  

            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {

            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }
        
        
    }


    void jumpEnd()
    {
        jumping = false;
        Invoke("setGrounded", 0.7f);

        characterAnimator.SetBool("jumping", jumping);
        FindObjectOfType<AudioManager>().Stop("Jump");
    }

    public void setJump(bool isTalking) 
    {
        diableJump = isTalking;
    }

    public void setGrounded() {

        grounded = true;
        trail.setGrounded(true);
       // Debug.Log("Grounded!");
    
    }

    public void landing() {

        FindObjectOfType<AudioManager>().Play("Landing");
        Invoke("endLanding", 0.3f);


    }
    public void endLanding()
    {
        FindObjectOfType<AudioManager>().Stop("Landing");
    }

    public void setDialogue(bool isTalking) 
    {

        Debug.Log("Jump disabled");
        dialogue = isTalking;
    }













}
