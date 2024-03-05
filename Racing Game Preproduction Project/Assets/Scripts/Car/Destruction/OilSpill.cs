using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class OilSpill : MonoBehaviour
{
    public float slipValueSmallCar = 2;
    public float slipValueMediumCar = 2;
    public float slipValueLargeCar = 2;

    //valuse for the small car
    public float rotationVelocitySMALL = 1;
    public float angularDragSMALL = 1;
    public float slipModifySMALL = 1;
    public float gripxAxisSMALL = 1;
    public float rotationSMALL = 1;

    //valuse for the medium car
    public float rotationVelocityMED = 1;
    public float angularDragMED = 1;
    public float slipModifyMED = 1;
    public float gripxAxisMED = 1;
    public float rotationMED = 1;


    //values for the large car
    public float rotationVelocityLARGE = 1.5f;
    public float angularDragLARGE = 0f;
    public float slipModifyLARGE = 100f;
    public float gripxAxisLARGE = 0f;
    public float rotationLARGE = 280;




    public float slipTest;
    
    public DriftController driftControllerScript;
   

    private void Start()
    {

        driftControllerScript = this.gameObject.GetComponent<DriftController>();
       

    }


    private void OnTriggerEnter(Collider Oil) //collision detection
    {

        if (Oil.gameObject.tag == "Oil" && this.gameObject.tag == ("Small Car")) 
        {

            driftControllerScript.RotVel += rotationVelocitySMALL;
            driftControllerScript.AngDragG += angularDragSMALL;
            driftControllerScript.SlipMod += slipModifySMALL;
            driftControllerScript.GripX += gripxAxisSMALL;
            driftControllerScript.Rotate += rotationSMALL;
            Debug.Log("Slip Active");
            //code for effecting car turning
            StartCoroutine(OilSpinnerSmall());

        }


        if (Oil.gameObject.tag == "Oil" && this.gameObject.tag == ("Medium Car"))
        {
            driftControllerScript.RotVel += rotationVelocityMED;
            driftControllerScript.AngDragG += angularDragMED;
            driftControllerScript.SlipMod += slipModifyMED;
            driftControllerScript.GripX += gripxAxisMED;
            driftControllerScript.Rotate += rotationMED;
            Debug.Log("Slip Active");
            //code for effecting car turning
            StartCoroutine(OilSpinnerMedium());

        }


        if (Oil.gameObject.tag == "Oil" && this.gameObject.tag == ("Large Car"))
        {


            driftControllerScript.RotVel += rotationVelocityLARGE;
            driftControllerScript.AngDragG += angularDragLARGE;
            driftControllerScript.SlipMod += slipModifyLARGE;
            driftControllerScript.GripX += gripxAxisLARGE;
            driftControllerScript.Rotate += rotationLARGE;
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
    
        yield return new WaitForSeconds(slipValueSmallCar);
        //resetting to defauls drivning settings for this car type..
        driftControllerScript.RotVel -= rotationVelocitySMALL;
        driftControllerScript.AngDragG -= angularDragSMALL;
        driftControllerScript.SlipMod -= slipModifySMALL;
        driftControllerScript.GripX -= gripxAxisSMALL;
        driftControllerScript.Rotate -= rotationSMALL;
        Debug.Log("Slip Stopped");


    }
    IEnumerator OilSpinnerMedium()
    {
        //temp change of car settings...
     
        yield return new WaitForSeconds(slipValueMediumCar);
        //resetting to defauls drivning settings for this car type..
        driftControllerScript.RotVel -= rotationVelocityMED;
        driftControllerScript.AngDragG -= angularDragMED;
        driftControllerScript.SlipMod -= slipModifyMED;
        driftControllerScript.GripX -= gripxAxisMED;
        driftControllerScript.Rotate -= rotationMED;
        Debug.Log("Slip Stopped");



    }
    IEnumerator OilSpinnerLarge()
    {
        //temp change of car settings...

       
        yield return new WaitForSeconds(slipValueLargeCar);
        //resetting to defauls drivning settings for this car type..

        driftControllerScript.RotVel -= rotationVelocityLARGE;
        driftControllerScript.AngDragG -= angularDragLARGE;
        driftControllerScript.SlipMod -= slipModifyLARGE;
        driftControllerScript.GripX -= gripxAxisLARGE;
        driftControllerScript.Rotate -= rotationLARGE;
        Debug.Log("Slip Stopped");



    }




}




