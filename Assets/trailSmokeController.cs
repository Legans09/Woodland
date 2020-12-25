using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailSmokeController : MonoBehaviour
{


    public GameObject frontTrail;
    public GameObject backTrail;
    private bool grounded =true;
    public Transform frontTrailTransform;
    public Transform backTrailTransform;
    public float endDelay=0.5f;
    public float startDelay=0.2f;
    public bool faceRight =false;
    public float offset = 0f;
    private ParticleSystem particleS;

    public Vector3 rotateLeft = new Vector3(0, 180, 0);
    public Vector3 rotateRight = new Vector3(0, -180, 0);


    private void Awake()
    {
        particleS = GetComponentInChildren<ParticleSystem>();
    }
    private void Start()
    {
      //  particleS.Stop(true);
    }


    public void setGrounded(bool isGrounded)
    {
        grounded = isGrounded;
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetButton("Horizontal") )
        {

            //backTrail.SetActive(true);
            particleS.enableEmission = true;
            //        frontTrail.SetActive(true);

            // if (Input.GetKey("right"))
            /*
             if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d")) && !faceRight)
                 {
                 frontTrailTransform.Rotate(rotateRight);
                 backTrailTransform.Rotate(rotateRight);
                   }
             else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a") && faceRight)
             {
                 frontTrailTransform.Rotate(rotateLeft);
                 backTrailTransform.Rotate(rotateLeft);
             }
            */
        }
        else
        {
            //  backTrail.SetActive(false);


            // frontTrail.SetActive(false);
            //   particleS.Stop(true);
            particleS.enableEmission = false;
            Debug.Log("boom");
          //  Invoke("endTrail", endDelay);
        }
    }


    public void setFaceRight(bool isFaceRight)
    {
        if (faceRight)
        {
            if (!isFaceRight) 
            {
                backTrailTransform.Rotate(rotateRight);

            }
        
        }

        if (!faceRight)
        {
            if (isFaceRight)
            {
               backTrailTransform.Rotate(rotateLeft);
            }

        }


        faceRight = isFaceRight;

        Debug.Log("TURN!");
    }

}
