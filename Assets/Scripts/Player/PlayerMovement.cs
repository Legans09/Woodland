
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    
    private Rigidbody2D rb2d;
    public Animator characterAnimator;
    public Transform player;
    
    public bool left = false;
    public bool pushRight = false;
    public bool pushLeft = false;
    //private bool pause = false;
    private bool dialogue = false;

    public float restartDelay = 10f;
    public float acceleration;
    public float speed;


    private Vector3 rotateLeft = new Vector3(0, -180, 0);
    private Vector3 rotateRight = new Vector3(0, 180, 0);
    private Vector2 rightVec = new Vector3(1f, 0f);
    private Vector2 leftVec = new Vector3(0f, 1f);

    [Range( 0,10)]
    public float turnSpeed = 1.3f;



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
      
    }

    void Update()
   
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
                acceleration += 0.013f;
            characterAnimator.SetFloat("speed", acceleration);
        }
        else
        {
            if (acceleration > 0)
                acceleration -= 0.025f;
            characterAnimator.SetFloat("speed", acceleration);
        }


        if (((Input.GetKey("left")) ||Input.GetKey("a")) && dialogue == false)
        {
            
            if (left == false)
            {
                Vector2 turn = new Vector2(turnSpeed, 0f);
                player.Rotate(rotateLeft);
                //Rotate Left Animation 
                rb2d.AddForce(turn * Time.deltaTime * speed);
                left = true;
            }
        }
        if (((Input.GetKey("right")) || Input.GetKey("d")) && dialogue == false)
        {
            if (left == true)
            {

                
                Vector2 turn = new Vector2(-turnSpeed, 0f);
                //Rotate Right Animation 
                rb2d.AddForce(turn * Time.deltaTime * speed);

                player.Rotate(rotateRight);
                left = false;
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
}
