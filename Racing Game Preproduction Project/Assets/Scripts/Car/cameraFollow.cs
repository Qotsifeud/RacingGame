using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform firstPersonTarget;
    public Transform thirdPersonTarget;


    public float thirdPdistance = 10f;
    public float thirdPheight = 0.65f;
    public float thirdPdamping = 15f;
    public float thirdProtationDamping = 15f;

    //this just adjusts the position of the cameras for each car...
    public float smallCarAdjustment = 10f;
    public float mediumCarAdjustment = 10f;
    public float largeCarAdjustment = 10f;

    //this adjusts the distance of the camera when past the below speed/ value set...
    public float smallCarDistanceAtSpeed = -10f;
    public float mediumCarDistanceAtSpeed = -10f;
    public float largeCarDistanceAtSpeed = -10f;


    //if the current speed is greater than this value then cointinue with the code...
    public float speedOfSmallCarWhenCamDistanceChanges = 10f;
    public float speedOfMediumCarWhenCamDistanceChanges = 10f;
    public float speedOfLargeCarWhenCamDistanceChanges = 10f;

    //this determines with car is currently in the game and executes the code depending on the car type...
    public bool smallCarCameraInUse = false;
    public bool mediumCarCameraInUse = false;
    public bool largeCarCameraInUse = false;
    public GameObject smallCar;
    public GameObject mediumCar;
    public GameObject largeCar;

    //default variables for small car not medium or large
    public float firstPdistance = 5.5f;
    public float firstPheight = 0.10f;
    public float firstPdamping = 300f;
    public float firstProtationDamping = 300f;

    public bool smoothRotation = true;
    public bool followBehind = true;

    public DriftController speed;
    public float CurrentSpeed;



    private void Start()
    {
        
        smallCar = GameObject.Find("Small Car");
        mediumCar = GameObject.Find("Medium Car");
        largeCar = GameObject.Find("Large Car");

        if(smallCar != null)
        {
            smallCarCameraInUse = true;
        }

        if (mediumCar != null)
        {
            mediumCarCameraInUse = true;
        }

        if (largeCar != null)
        {
            largeCarCameraInUse = true;
        }

    }




    void Update()
    {//default third person camera
        CurrentSpeed = speed.CurrentSpeed;

        //LARGE CAR....................................................................................................................

        if (DriftController.thirdPersonCamera == true && largeCarCameraInUse == true)
        {
            
            Vector3 wantedPosition;

            if (CurrentSpeed > speedOfLargeCarWhenCamDistanceChanges)
                thirdPdistance = largeCarAdjustment + (CurrentSpeed - largeCarDistanceAtSpeed) / 10;
            else
                thirdPdistance = largeCarAdjustment;
            
            if (followBehind)
                wantedPosition = thirdPersonTarget.TransformPoint(0, thirdPheight, -thirdPdistance);
            else
                wantedPosition = thirdPersonTarget.TransformPoint(0, thirdPheight, thirdPdistance);

            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * thirdPdamping);

            if (smoothRotation)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(thirdPersonTarget.position - transform.position, thirdPersonTarget.up);
                //Quaternion ownRotation = Quaternion.RotateTowards;
                transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * thirdProtationDamping);
            }
            else transform.LookAt(thirdPersonTarget, thirdPersonTarget.up);

        }

        else if(DriftController.thirdPersonCamera == false && largeCarCameraInUse == true)
        {

            Vector3 wantedPosition;
            if (followBehind)
                wantedPosition = firstPersonTarget.TransformPoint(0, firstPheight, -firstPdistance);
            else
                wantedPosition = firstPersonTarget.TransformPoint(0, firstPheight, firstPdistance);

            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * firstPdamping);

            if (smoothRotation)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(firstPersonTarget.position - transform.position, firstPersonTarget.up);
                //Quaternion ownRotation = Quaternion.RotateTowards;
                transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * firstProtationDamping);
            }
            else transform.LookAt(firstPersonTarget, firstPersonTarget.up);

        }

        //MEDIUM CAR....................................................................................................................

        if (DriftController.thirdPersonCamera == true && mediumCarCameraInUse == true)
        {

            Vector3 wantedPosition;

            if (CurrentSpeed > speedOfMediumCarWhenCamDistanceChanges)
                thirdPdistance = mediumCarAdjustment + (CurrentSpeed - mediumCarDistanceAtSpeed) / 10;
            else
                thirdPdistance = mediumCarAdjustment;

            if (followBehind)
                wantedPosition = thirdPersonTarget.TransformPoint(0, thirdPheight, -thirdPdistance);
            else
                wantedPosition = thirdPersonTarget.TransformPoint(0, thirdPheight, thirdPdistance);

            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * thirdPdamping);

            if (smoothRotation)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(thirdPersonTarget.position - transform.position, thirdPersonTarget.up);
                //Quaternion ownRotation = Quaternion.RotateTowards;
                transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * thirdProtationDamping);
            }
            else transform.LookAt(thirdPersonTarget, thirdPersonTarget.up);

        }

        else if (DriftController.thirdPersonCamera == false && mediumCarCameraInUse == true)
        {

            Vector3 wantedPosition;
            if (followBehind)
                wantedPosition = firstPersonTarget.TransformPoint(0, firstPheight, -firstPdistance);
            else
                wantedPosition = firstPersonTarget.TransformPoint(0, firstPheight, firstPdistance);

            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * firstPdamping);

            if (smoothRotation)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(firstPersonTarget.position - transform.position, firstPersonTarget.up);
                //Quaternion ownRotation = Quaternion.RotateTowards;
                transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * firstProtationDamping);
            }
            else transform.LookAt(firstPersonTarget, firstPersonTarget.up);

        }

        //SMALL CAR....................................................................................................................

        if (DriftController.thirdPersonCamera == true && smallCarCameraInUse == true)
        {

            Vector3 wantedPosition;

            if (CurrentSpeed > speedOfSmallCarWhenCamDistanceChanges)
                thirdPdistance = smallCarAdjustment + (CurrentSpeed - smallCarDistanceAtSpeed) / 10;
            else
                thirdPdistance = smallCarAdjustment;

            if (followBehind)
                wantedPosition = thirdPersonTarget.TransformPoint(0, thirdPheight, -thirdPdistance);
            else
                wantedPosition = thirdPersonTarget.TransformPoint(0, thirdPheight, thirdPdistance);

            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * thirdPdamping);

            if (smoothRotation)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(thirdPersonTarget.position - transform.position, thirdPersonTarget.up);
                //Quaternion ownRotation = Quaternion.RotateTowards;
                transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * thirdProtationDamping);
            }
            else transform.LookAt(thirdPersonTarget, thirdPersonTarget.up);

        }

        else if (DriftController.thirdPersonCamera == false && smallCarCameraInUse == true)
        {

            Vector3 wantedPosition;
            if (followBehind)
                wantedPosition = firstPersonTarget.TransformPoint(0, firstPheight, -firstPdistance);
            else
                wantedPosition = firstPersonTarget.TransformPoint(0, firstPheight, firstPdistance);

            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * firstPdamping);

            if (smoothRotation)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(firstPersonTarget.position - transform.position, firstPersonTarget.up);
                //Quaternion ownRotation = Quaternion.RotateTowards;
                transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * firstProtationDamping);
            }
            else transform.LookAt(firstPersonTarget, firstPersonTarget.up);

        }

    }
}
