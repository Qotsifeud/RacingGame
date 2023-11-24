using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform car;

    [HideInInspector] public float rotationSpeedSpoiler;
    [HideInInspector] public float rotationSpeedWeight;
    [HideInInspector] public float rotationSpeedBreaks;
    [HideInInspector] public Vector3 rotationSpeedVector;
    [HideInInspector] public Vector3 rotationSpeedReversedVector;
    [HideInInspector] public float rotationAcceleration;


    public float speed = 17;
    [HideInInspector] public float movementSpeedSpoiler;
    [HideInInspector] public float movementSpeedWeight;
    [HideInInspector] public float movementSpeedBreaks;
    [HideInInspector] public Vector3 movementSpeedVector;
    [HideInInspector] public float acceleration;

    [HideInInspector] public float accelerationMulitplierSpoiler;
    [HideInInspector] public float accelerationMulitplierWight;
    [HideInInspector] public float accelerationMulitplierBreaks;

    [HideInInspector] public float rotataionMulitplierSpoiler;
    [HideInInspector] public float rotataionMulitplierWeight;
    [HideInInspector] public float rotataionMulitplierBreaks;

    [HideInInspector] public float breakMulitplierSpoiler;
    [HideInInspector] public float breakMulitplierWight;
    [HideInInspector] public float breakMulitplierBreaks;

    [HideInInspector] public float movementVector;
    [HideInInspector] public float rotationVector;
    [HideInInspector] public float accelerationMulitplier;
    [HideInInspector] public float rotataionMulitplier;
    [HideInInspector] public float breakMulitplier;

    public float speedBase = 1;
    public float accelerationBase = 1;
    public float rotationBase = 60;
    public float rotationSpeedBase = 2;
    public float breakBase = 1;


    //public GameObject respawnPoint;
    [HideInInspector] public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationVector = rotationBase + rotationSpeedSpoiler + rotationSpeedWeight + rotationSpeedBreaks;

        rotationSpeedVector = new Vector3(0, rotationVector, 0);
        rotationSpeedReversedVector = new Vector3(0, -rotationVector, 0);

        movementVector = speedBase + movementSpeedSpoiler + movementSpeedWeight + movementSpeedBreaks;

        movementSpeedVector = new Vector3(0, 0, movementVector);

        accelerationMulitplier = accelerationBase + accelerationMulitplierSpoiler + accelerationMulitplierWight + accelerationMulitplierBreaks;

        rotataionMulitplier = rotationSpeedBase + rotataionMulitplierSpoiler + rotationSpeedWeight + rotationSpeedBreaks;

        breakMulitplier = breakBase + breakMulitplierSpoiler + breakMulitplierWight + breakMulitplierBreaks;

        if (Input.GetKey("w") && canMove) // forward Acceleration
        {
            acceleration += Time.deltaTime * accelerationMulitplier;

            if (acceleration > 1)
            {
                acceleration = 1;
            }

            transform.Translate(movementSpeedVector * speed * Time.deltaTime * acceleration);

        }
        else if (Input.GetKey("s") && canMove) // backwards acceleration
        {
            acceleration -= Time.deltaTime * accelerationMulitplier;

            if (acceleration < -1)
            {
                acceleration = -1;
            }
            transform.Translate(movementSpeedVector * speed * Time.deltaTime * acceleration);


        }
        else // breaking / neutral acceleration 
        {
            if (acceleration <= 1 && acceleration > 0.25) 
            {
                acceleration -= Time.deltaTime * breakMulitplier;
            }
            else if (acceleration >= -1 && acceleration < -0.25)
            {
                acceleration += Time.deltaTime * breakMulitplier;
            }
            else if (acceleration < 0.25 || acceleration > -0.25)
            {
                acceleration = 0;
            }
            transform.Translate(movementSpeedVector * speed * Time.deltaTime * acceleration);

        }

        if (Input.GetKey("d") && acceleration != 0) // right turns
        {
            rotationAcceleration += Time.deltaTime * rotataionMulitplier;

             if (rotationAcceleration > 1)
             {
                rotationAcceleration = 1;
             }

             if (acceleration > 0)
             {
                 Quaternion deltaRotation = Quaternion.Euler(rotationSpeedVector * Time.deltaTime * rotationAcceleration);
                 rb.MoveRotation(rb.rotation * deltaRotation);
             }
             else if (acceleration < 0) // reverse rotation for driving backwards 
             {
                 Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversedVector * Time.deltaTime * rotationAcceleration);
                 rb.MoveRotation(rb.rotation * deltaRotation);
             }

        }
        else if (Input.GetKey("a") && acceleration != 0) // left turns
        {
            rotationAcceleration -= Time.deltaTime * rotataionMulitplier;

            if (rotationAcceleration < -1)
            {
                rotationAcceleration = -1;
            }

            if (acceleration > 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(rotationSpeedVector * Time.deltaTime * rotationAcceleration);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            else if (acceleration < 0) // reverse rotation for driving backwards 
            {
                Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversedVector * Time.deltaTime * rotationAcceleration);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }

        }

        else // resets strearing position when not activley stearing
        {
            if (rotationAcceleration <= 1 && rotationAcceleration > 0.25)
            {
                rotationAcceleration -= Time.deltaTime * rotataionMulitplier;
            }
            else if (rotationAcceleration >= -1 && rotationAcceleration < -0.25)
            {
                rotationAcceleration += Time.deltaTime * rotataionMulitplier;

            }
            else if (rotationAcceleration < 0.25 || rotationAcceleration > -0.25)
            {
                rotationAcceleration = 0;
            }

            if (acceleration > 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(rotationSpeedVector * Time.deltaTime * rotationAcceleration);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            else if (acceleration < 0) // reverse rotation for drifting backwards 
            {
                Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversedVector * Time.deltaTime * rotationAcceleration);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }

        }
        
    }
}
