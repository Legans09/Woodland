using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashAnimation : MonoBehaviour
{
    private Animator slashAnimator;
    private SpriteRenderer slash;
    public float slashDuration = 2f;



    private void Awake()
    {
        slashAnimator = GetComponent<Animator>();
        slash = GetComponent<SpriteRenderer>();
    }



    public void setSlash()
    {
        slash.enabled = true;
        Invoke("slashEnd", slashDuration);
        slashAnimator.SetBool("isAttacking", true);
    }



    void slashEnd()
    {
        slash.enabled = false;
    }

}
