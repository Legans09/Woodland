
using UnityEngine;
using TMPro;


public class textTrigger1 : MonoBehaviour
{


    public TMP_Text text1;
    public DialogueTrigger diaTrigger;
    public float restartDelay = 2f;
    public float textSpeed;
    public bool triggered = false;


    public void OnTriggerEnter()
    {
        if (triggered == false)
        {
            triggered = true;


            diaTrigger.TriggerDialogue();
            
        }
    }

}






