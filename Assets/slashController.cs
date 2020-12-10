using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashController : MonoBehaviour
{

    public slashAnimation slashA;



    public void triggerSlash()
    {
        slashA.setSlash();
    }
}
