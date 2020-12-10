using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSlash : MonoBehaviour
{

    public slashAnimation slash;


    private void Awake()
    {
        slash = FindObjectOfType<slashAnimation>();
    }



    
    public void setSlash()
    {

        slash.setSlash();

    }



}
