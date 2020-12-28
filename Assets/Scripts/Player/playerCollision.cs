
using UnityEngine;

public class playerCollision : MonoBehaviour
{

   
    public JumpController jumpControl;
    public Rigidbody2D rb2d;
    public GameManager gameManager;



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        
        /*
        if (collisionInfo.gameObject.tag == "Obstacle")

        {

           // UnityEngine.Debug.Log("We hit Obstacle");

            movement.enabled = false;
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
                
            FindObjectOfType<GameManager>().EndGame();
            
         }
        */


        if (collisionInfo.gameObject.tag == "Ground")

        {
            

            jumpControl.setGrounded();

             Debug.Log("Contact");
            
            
        }

       


    }
}
 