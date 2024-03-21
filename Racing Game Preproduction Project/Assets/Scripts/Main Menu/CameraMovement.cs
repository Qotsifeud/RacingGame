using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public GameObject doorR;
    public GameObject doorL;
    private bool openTheDoors;
    public GameObject bathroomDoor;
    public GameObject exitDoor;
    public GameObject garageDoor;
    public GameObject mainMenuButtons;
    private bool openBathroomDoor;
    private bool openExitDoor;
    private bool openGarageDoor;
    private bool MainMenuActive;
    private Animator doorAnimations;
    private Animator exitDoorObject;
    private Animator backDoorObject;

    public Vector3[] cameraLocations;

    public Vector3 targetLocation;

    private Vector3 currentVelocity;
    private Vector3 desiredVelocity;
    private Vector3 steeringVelocity;


    private float distanceToTaget;
    private float maxVelocity = 100f;
    private float maxForce = 5f;

    private float rotationSpeed = 5;

    public Vector3[] cameraAngles;

    public Vector3 targetAngle;

    public bool ableToMove = false;

    private Rigidbody rb;

    private bool canchange = false;

    //canvas Objects
    public GameObject canvas;

    public GameObject carCustomisation;
    public GameObject charachterCustomisation;
    public GameObject exit;
    public GameObject settings;
    public GameObject leaderboard;
    public GameObject play;
    

    // Stuff for doors
    private float currentDistance = 0f;

    public void Start()
    {
        mainMenuButtons.SetActive(false);
        MainMenuActive = false;
        openTheDoors = false;
        doorAnimations = bathroomDoor.GetComponent<Animator>();
        exitDoorObject = exitDoor.GetComponent<Animator>();
        backDoorObject = garageDoor.GetComponent<Animator>();
    }
    public void startButton()
    {
        rb = GetComponent<Rigidbody>();
        targetLocation = new Vector3(0.17f, 2.53f, 21.41f);
        targetAngle = new Vector3(9.419f, 0f, 0f);
        ableToMove = true;

        openTheDoors = true;

        MainMenuActive = true;




    }


    //Bathroom door test code.........................
    public void doorOpen()
    {
        openBathroomDoor = true;

    }
    public void doorclose()
    {
        openBathroomDoor = false;

    }
    public void exitOpen()
    {
        openExitDoor = true;

    }
    public void exitClosed()
    {
        openExitDoor = false;

    }
    public void backOpen()
    {
        openGarageDoor = true;

    }
    public void backClosed()
    {
        openGarageDoor = false;

    }

    private void Update()
    {

        if (MainMenuActive)
        {
            StartCoroutine(WaitForMenu());
        }






        if (currentDistance < 1.7f && openTheDoors)
        {
            currentDistance += Time.deltaTime;
            OpneMainDoors(currentDistance);
        }
        /////////////////////////////////////////////////////////////////////////////////
        if (openBathroomDoor)
        {//play anim door opened

            doorAnimations.SetBool("isOpen", true);

        }

        if (!openBathroomDoor)
        {//play anim door closed

            doorAnimations.SetBool("isOpen", false);
        }
        if (openExitDoor)
        {//play anim door opened

            exitDoorObject.SetBool("exitOpen", true);

        }

        if (!openExitDoor)
        {//play anim door closed

            exitDoorObject.SetBool("exitOpen", false);
        }
        if (openGarageDoor)
        {//play anim door opened

            backDoorObject.SetBool("backDoorOpen", true);

        }

        if (!openGarageDoor)
        {//play anim door closed

            backDoorObject.SetBool("backDoorOpen", false);
        }
        ////////////////////////////////////////////////////////////////////////////////


        distanceToTaget = Vector3.Distance(transform.position, targetLocation);

        if(ableToMove)
        {
            MoveCamera(targetLocation);
            RotateCamera(targetAngle);

            if (distanceToTaget < 0.1f)
            {
                canvas.SetActive(true);
                ableToMove = false;
                canchange = true;
            }
        }



    }

    IEnumerator WaitForMenu()
    {
        yield return new WaitForSeconds(5);
        mainMenuButtons.SetActive(true);
    }

    private void MoveCamera(Vector3 target)
    {
        desiredVelocity = (target - transform.position).normalized * maxVelocity;

        steeringVelocity = desiredVelocity - currentVelocity;
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, maxForce);
        steeringVelocity /= rb.mass;

        currentVelocity += steeringVelocity;
        currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxForce);

        transform.position += currentVelocity * Time.deltaTime;
    }

    private void RotateCamera(Vector3 targetAngle)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetAngle), Time.deltaTime * rotationSpeed);

        //transform.rotation = Quaternion.Euler(targetAngle);
    }

    public void MoveToCar()
    {
        if (canchange)
        {
            clearcanvas();
            targetLocation = cameraLocations[0];
            targetAngle = cameraAngles[0];
            ableToMove = true;
            canchange = false;
            canvas = carCustomisation;
        }
    }

    public void MoveToExit()
    {
        if (canchange)
        {
            clearcanvas();
            targetLocation = cameraLocations[1];
            targetAngle = cameraAngles[1];
            ableToMove = true;
            canchange = false;
            canvas = exit;
        }
    }
    public void MoveToCharacter()
    {
        if (canchange)
        {
            clearcanvas();
            targetLocation = cameraLocations[2];
            targetAngle = cameraAngles[2];
            ableToMove = true;
            canchange = false;
            canvas = charachterCustomisation;
        }
    }

    public void MoveToPlay()
    {
        if (canchange)
        {
            clearcanvas();
            targetLocation = cameraLocations[3];
            targetAngle = cameraAngles[3];
            ableToMove = true;
            canchange = false;
            canvas = play;
        }
    }
    public void MoveToSettings()
    {
        if (canchange)
        {
            clearcanvas();
            targetLocation = cameraLocations[4];
            targetAngle = cameraAngles[4];
            ableToMove = true;
            canchange = false;
            canvas = settings;
        }
    }
    public void MoveToLeaderboad()
    {
        if (canchange)
        {
            clearcanvas();
            targetLocation = cameraLocations[5];
            targetAngle = cameraAngles[5];
            ableToMove = true;
            canchange = false;
            canvas = leaderboard;
        }
    }

    private void clearcanvas()
    {
        canvas.SetActive(false);
    }

    private void OpneMainDoors(float distance)
    {
        doorR.transform.position = new Vector3 (distance +2, doorR.transform.position.y, doorR.transform.position.z);
        doorL.transform.position = new Vector3 (-distance -2 , doorL.transform.position.y, doorL.transform.position.z);
    }

}
