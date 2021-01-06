
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
    public float rTail = -1.0F;
    public float lTail = 1.0F;

    public Vector3 rotateLeft = new Vector3(0, 180, 0);
    public Vector3 rotateRight = new Vector3(0, -180, 0);
    private float accelaration;


    public PlayerMovement movement;


    private void Awake()
    {
        particleS = GetComponentInChildren<ParticleSystem>();
        movement = FindObjectOfType<PlayerMovement>();
        
    }

    public void setGrounded(bool isGrounded)
    {
        grounded = isGrounded;
    }

    [System.Obsolete]
    private void Update()
    {

        accelaration = movement.getAcceleration();


        if (Input.GetButton("Horizontal") )
        {
            if(accelaration>1.3f)
            particleS.enableEmission = true;
        }
        else
        {        
            particleS.enableEmission = false;
        }
    }


    public void setFaceRight(bool isFaceRight)
    {
        if (faceRight)
        {
            if (!isFaceRight) 
            {
                // backTrailTransform.Rotate(rotateRight);
                //  transform.rotation = Quaternion.Slerp(transform.rotation, backTrailTransform.rotation, Time.deltaTime * 5f); ;


               backTrailTransform.transform.eulerAngles = new Vector3(
               backTrailTransform.transform.eulerAngles.x,
               backTrailTransform.transform.eulerAngles.y - 180,
               backTrailTransform.transform.eulerAngles.z
              );
                Debug.Log("Turninng right");

             //   particleS.startRotation = gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            }
        }

        if (!faceRight)
        {
            if (isFaceRight)
            {
                //  backTrailTransform.Rotate(rotateLeft);  
                //   transform.rotation = Quaternion.Slerp(transform.rotation, backTrailTransform.rotation, Time.deltaTime * 5f); ;
                backTrailTransform.transform.eulerAngles = new Vector3(
                           backTrailTransform.transform.eulerAngles.x,
                           backTrailTransform.transform.eulerAngles.y + 180,
                           backTrailTransform.transform.eulerAngles.z
                          );
                Debug.Log("Turninng left");
                //  particleS.startRotation = gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            }

        }


        faceRight = isFaceRight;

        Debug.Log("TURN!");
    }

}
