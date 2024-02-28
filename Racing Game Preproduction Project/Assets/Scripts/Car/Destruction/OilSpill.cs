using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class OilSpill : MonoBehaviour
{

    public bool hastriggeredOil;
    private DriftController driftControllerScript;
    private float currentslipStatus;

    //values added onto default
    private float largeCarSlipValue = 100;
    private float mediumCarSlipValue = 100;
    private float smallCarSlipValue = 100;

    private void Start()
    {

        driftControllerScript = this.gameObject.GetComponent<DriftController>();
        currentslipStatus = driftControllerScript.SlipMod;


        hastriggeredOil = false;
    }


    private void OnTriggerEnter(Collider Oil) //collision detection
    {

        if (Oil.gameObject.tag == "Oil" && hastriggeredOil == false && this.gameObject.tag == ("Small Car")) 
        {
            hastriggeredOil = false;

            //code for effecting car turning
            StartCoroutine(OilSpinnerSmall());

            //Destroy(Oil.gameObject);
        }


        if (Oil.gameObject.tag == "Oil" && hastriggeredOil == false && this.gameObject.tag == ("Medium Car"))
        {
            hastriggeredOil = false;

            //code for effecting car turning
            StartCoroutine(OilSpinnerMedium());

            //Destroy(Oil.gameObject);
        }


        if (Oil.gameObject.tag == "Oil" && hastriggeredOil == false && this.gameObject.tag == ("Large Car"))
        {
            hastriggeredOil = false;

            //code for effecting car turning
            StartCoroutine(OilSpinnerLarge());

            //Destroy(Oil.gameObject);
        }



    }

    //this works for now
    //TODO: add in the slide physics to the wheels???
    IEnumerator OilSpinnerSmall()
    { 
        //temp change of car settings...
    

        currentslipStatus += currentslipStatus * smallCarSlipValue;

        yield return new WaitForSeconds(4);
        //resetting to defauls drivning settings for this car type..



    }
    IEnumerator OilSpinnerMedium()
    {
        //temp change of car settings...
     

        currentslipStatus += currentslipStatus * mediumCarSlipValue;

        yield return new WaitForSeconds(4);
        //resetting to defauls drivning settings for this car type..




    }
    IEnumerator OilSpinnerLarge()
    {
        //temp change of car settings...
     

        currentslipStatus += currentslipStatus * largeCarSlipValue;

        yield return new WaitForSeconds(4);
        //resetting to defauls drivning settings for this car type..




    }




}




