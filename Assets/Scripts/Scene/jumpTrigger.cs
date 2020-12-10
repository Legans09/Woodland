using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
{


    public Animator animator;
    public BetterJump jumpControl;


    private void Awake()
    {
        jumpControl = FindObjectOfType<BetterJump>();
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.enabled = true;
        jumpControl.enabled = true;
    }

}
