using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class diaBoxController : MonoBehaviour
{
   
    public GameObject diaBox;
    public bool visable = false;


    public void Awake()
    {
        //diaBox = GetComponent<GameObject>();
    }



     void Update()
    {
        if (visable)
        {
            diaBox.SetActive(true);

        }
        else {

            diaBox.SetActive(false);
        }


       
       
    }


    public void setVisable(bool state) 
    {
        visable = state;
    }

   
    







}
