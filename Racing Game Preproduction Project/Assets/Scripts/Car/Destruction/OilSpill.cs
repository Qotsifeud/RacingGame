using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class OilSpill : MonoBehaviour
{

    public bool hastriggeredOil;

    private void Start()
    {
        hastriggeredOil = false;
    }


    private void OnTriggerEnter(Collider Oil) //collision detection
    {

        if (Oil.gameObject.tag == "Oil" && hastriggeredOil == false) 
        {
            hastriggeredOil = false;

            //code for effecting car turning









            //Destroy(Oil.gameObject);
        }



    }


}




