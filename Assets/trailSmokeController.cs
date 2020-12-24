using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailSmokeController : MonoBehaviour
{


    public GameObject frontTrail;
    public GameObject backTrail;
    private bool grounded =true;


    public void setGrounded(bool isGrounded)
    {
        grounded = isGrounded;
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") )
        {

            backTrail.SetActive(true);
            frontTrail.SetActive(true);
        }
        else
        {
            backTrail.SetActive(false);
            frontTrail.SetActive(false);
        }
    }





}
