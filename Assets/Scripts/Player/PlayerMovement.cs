
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    
    private Rigidbody2D rb2d;
    public Animator characterAnimator;
    public Transform player;
    public trailSmokeController trail;
    
    public bool left = false;
    public bool pushRight = false;
    public bool pushLeft = false;
    //private bool pause = false;
    private bool dialogue = false;

    public float restartDelay = 10f;
    public float acceleration;
    public float speed;

    [Range(0, 1)]
    public float rotateDelay = 1f;


    private Vector3 rotateLeft = new Vector3(0, -180, 0);
    private Vector3 rotateRight = new Vector3(0, 180, 0);
    private Vector2 rightVec = new Vector3(1f, 0f);
    private Vector2 leftVec = new Vector3(0f, 1f);

    [Range( 0,10)]
    public float turnSpeed = 1.3f;



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        trail = FindObjectOfType<trailSmokeController>();
      
    }

    void FixedUpdate()
   
    {


       
        if (rb2d.position.y < -4f) 
        {

            FindObjectOfType<GameManager>().EndGame();

        }


        if ((Input.GetButton("Horizontal") && dialogue == false)|| pushRight||pushLeft)

        {
            float moveHorizontal = Input.GetAxis("Horizontal");        
            Vector2 movement = new Vector2(moveHorizontal, 0f);

            if (pushLeft)
            {
                movement = leftVec;
            }
            else if (pushRight)
            {
                movement = rightVec;
            }

            rb2d.AddForce(movement * Time.deltaTime * speed);



            if (acceleration < 2)
                acceleration += 0.012f;
            characterAnimator.SetFloat("speed", acceleration);
        }
        else
        {
            if (acceleration > 0)
                acceleration -= 0.029f;
            characterAnimator.SetFloat("speed", acceleration);
        }


        if (((Input.GetKey("left")) ||Input.GetKey("a")) && dialogue == false)
        {
            
            if (left == false)
            {
                Vector2 turn = new Vector2(turnSpeed, 0f);

                //Rotate Left Animation 
                // player.Rotate(rotateLeft);

                if (acceleration > 1f)
                {
                    Invoke("lRotate", rotateDelay);
                    characterAnimator.SetBool("turn", true);
                }
                else
                {
                    player.Rotate(rotateLeft);
                }

                rb2d.AddForce(turn * Time.deltaTime * speed);
                left = true;
                trail.setFaceRight(false);
            }
        }
        if (((Input.GetKey("right")) || Input.GetKey("d")) && !dialogue )
        {
            if (left == true)
            {
                Vector2 turn = new Vector2(-turnSpeed, 0f);

                //Rotate Right Animation 
                //player.Rotate(rotateRight);


                if (acceleration > 1f)
                {
                    Invoke("rRotate", rotateDelay);
                    characterAnimator.SetBool("turn", true);
                }
                else 
                {
                    player.Rotate(rotateRight);
                }

                rb2d.AddForce(turn * Time.deltaTime * speed);

              
                left = false;
                trail.setFaceRight(true);
            }

        }
    }


    public void pushingRight(float duration) 
    {
        pushRight = true;
        Invoke("resetPush", duration);
    }
    public void pushingLeft(float duration)
    {
        pushLeft = true;
        Invoke("resetPush", duration);
    }

    public void resetPush()
    {
        pushLeft = false;
        pushRight = false;
    }



    /*

    public void setPause()
    {

        pause = true;
        Invoke("setRun", restartDelay);
    }
    public void setRun()
    {
        pause = false;
        
    }
    */


    public void setDialogue(bool isTalking)
    {
        dialogue = isTalking;
    }



    public float getAcceleration()
    {
        return acceleration;
    }

    private void rotateCharacter()
    {    
        characterAnimator.SetBool("turn", false);
        player.Rotate(rotateLeft);
    }

    private void lRotate()
    {    
        characterAnimator.SetBool("turn", false);
        player.Rotate(rotateLeft);
    }

    private void rRotate()
    {
        characterAnimator.SetBool("turn", false);
        player.Rotate(rotateRight);
    }

}
