using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public GameObject door;

    public Vector3[] cameraLocations;

    public Vector3 targetLocation;

    private Vector3 currentVelocity;
    private Vector3 desiredVelocity;
    private Vector3 steeringVelocity;

    private float distanceToTaget;
    private float maxVelocity = 100f;
    private float maxForce = 5f;

    public Vector3[] cameraAngles;

    public Vector3 targetAngle;

    public bool ableToMove = false;

    private Rigidbody rb;

    public bool canchange = true;

    //canvas Objects
    public GameObject canvas;

    public GameObject carCustomisation;
    public GameObject charachterCustomisation;
    public GameObject exit;
    public GameObject settings;
    public GameObject leaderboard;
    public GameObject play;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetLocation = new Vector3(0.17f, 2.53f, 21.41f);
        targetAngle = new Vector3(9.419f, 0f, 0f);
        ableToMove = true;
    }

    private void Update()
    {   
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

    private void MoveCamera(Vector3 target)
    {
        desiredVelocity = (targetLocation - transform.position).normalized * maxVelocity;

        steeringVelocity = desiredVelocity - currentVelocity;
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, maxForce);
        steeringVelocity /= rb.mass;

        currentVelocity += steeringVelocity;
        currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxForce);

        transform.position += currentVelocity * Time.deltaTime;
    }

    private void RotateCamera(Vector3 targetAngle)
    {
        transform.rotation = Quaternion.Euler(targetAngle);
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
}
