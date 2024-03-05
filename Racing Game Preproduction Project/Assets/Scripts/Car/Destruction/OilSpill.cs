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
    public float rotationVelocitySMALL = 0.1f;
    public float angularDragSMALL = 0.1f;
    public float slipModifySMALL = 0.1f;
    public float gripxAxisSMALL = 0.1f;
    public float rotationSMALL = 0.1f;

    //valuse for the medium car
    public float rotationVelocityMED = 0.1f;
    public float angularDragMED = 0.1f;
    public float slipModifyMED = 0.1f;
    public float gripxAxisMED = 0.1f;
    public float rotationMED = 0.1f;


    //values for the large car
    public float rotationVelocityLARGE = 0.1f;
    public float angularDragLARGE = 0.1f;
    public float slipModifyLARGE = 0.1f;
    public float gripxAxisLARGE = 0.1f;
    public float rotationLARGE = 0.1f;




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




