using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public GameObject blocker;
    
    public bool active = false;

    private void Update()
    {
        if (active)
        {
            blocker.SetActive(false);
        }
        else
        {
            blocker.SetActive(true);
        }

    }

    public void setActive()
     {

        active = true;
     }




}
