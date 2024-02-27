using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        targetLocation = cameraLocations[0];
        targetAngle = cameraAngles[0];
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
                ableToMove = false;
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
}
