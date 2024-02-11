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


    //default variables for small car not medium or large
    public float firstPdistance = 5.5f;
    public float firstPheight = 0.10f;
    public float firstPdamping = 300f;
    public float firstProtationDamping = 300f;

    public bool smoothRotation = true;
    public bool followBehind = true;
    



    void Update()
    {//default third person camera

        if(DriftController.thirdPersonCamera == true)
        {
            

            Vector3 wantedPosition;
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

        else if(DriftController.thirdPersonCamera == false)
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
