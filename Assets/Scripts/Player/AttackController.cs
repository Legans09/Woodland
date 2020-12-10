using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private bool attacking = false;

    public Animator playerAnimator;
    public Animator slashAnimator;
    public SpriteRenderer slash;
    public float attackDuration;

  

    /*

    public void setAttacking(bool isAttacking) 
    {
        attacking = isAttacking;
    }


    */
    public void attack()
    {
        if (!attacking)
        {
            FindObjectOfType<AudioManager>().Play("Attack");
            playerAnimator.SetBool("attacking", true);
          //  slashAnimator.SetBool("isAttacking", true);
            // slashAnimator.enabled = true;

            attacking = true;

            Invoke("attackEnd", attackDuration);
        }
        }





     void attackEnd()
    {

        slash.enabled = false;
        playerAnimator.SetBool("attacking", false);
        attacking = false;
        FindObjectOfType<AudioManager>().Stop("Attack");
        slashAnimator.SetBool("isAttacking", false);
      // slashAnimator.enabled = false;

    }




    public void triggerSlash() 
    {

        slashAnimator.SetBool("isAttacking", true);


    }


}
