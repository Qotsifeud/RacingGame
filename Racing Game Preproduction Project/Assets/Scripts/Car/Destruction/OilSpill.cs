using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class OilSpill : MonoBehaviour
{

    
    public DriftController driftControllerScript;
   

    private void Start()
    {

        driftControllerScript = this.gameObject.GetComponent<DriftController>();
       
    }


    private void OnTriggerEnter(Collider Oil) //collision detection
    {

        if (Oil.gameObject.tag == "Oil" && this.gameObject.tag == ("Small Car")) 
        {
            //code for effecting car turning
            StartCoroutine(OilSpinnerSmall());
        }


        if (Oil.gameObject.tag == "Oil" && this.gameObject.tag == ("Medium Car"))
        {

            //code for effecting car turning
            StartCoroutine(OilSpinnerMedium());

        }


        if (Oil.gameObject.tag == "Oil" && this.gameObject.tag == ("Large Car"))
        {


            driftControllerScript.RotVel = 1.5f;
            driftControllerScript.AngDragG = 0f;
            driftControllerScript.SlipMod = 100f;
            driftControllerScript.GripX = 0f;
            driftControllerScript.Rotate = 280;
            Debug.Log("Slip Active");


            //code for effecting car turning
            StartCoroutine(OilSpinnerLarge());

        }

    }

    //this works for now
    //TODO: add in the slide physics to the wheels???
    IEnumerator OilSpinnerSmall()
    { 
        //temp change of car settings...
    
        yield return new WaitForSeconds(6);
        //resetting to defauls drivning settings for this car type..

    }
    IEnumerator OilSpinnerMedium()
    {
        //temp change of car settings...
     
        yield return new WaitForSeconds(6);
        //resetting to defauls drivning settings for this car type..

    }
    IEnumerator OilSpinnerLarge()
    {
        //temp change of car settings...

       
        yield return new WaitForSeconds(6);
        //resetting to defauls drivning settings for this car type..

        driftControllerScript.RotVel = 0.7f;
        driftControllerScript.AngDragG = 5.0f;
        driftControllerScript.SlipMod = 10.0f;
        driftControllerScript.GripX = 12f;
        driftControllerScript.Rotate = 140f;
        Debug.Log("Slip Stopped");

    }
}




