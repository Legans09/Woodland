using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
{


    public Animator animator;
    public JumpController jumpControl;


    private void Awake()
    {
        jumpControl = FindObjectOfType<JumpController>();
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.enabled = true;
        jumpControl.enabled = true;
    }

}
