using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform car;

    public float rotationSpeedSpoiler;
    public float rotationSpeedWeight;
    public float rotationSpeedBreaks;
    public Vector3 rotationSpeedVector;
    public Vector3 rotationSpeedReversedVector;
    public float rotationAcceleration;


    public float speed = 17;
    public float movementSpeedSpoiler;
    public float movementSpeedWeight;
    public float movementSpeedBreaks;
    public Vector3 movementSpeedVector;
    public float acceleration;

    public float accelerationMulitplierSpoiler;
    public float accelerationMulitplierWight;
    public float accelerationMulitplierBreaks;

    public float rotataionMulitplierSpoiler;
    public float rotataionMulitplierWeight;
    public float rotataionMulitplierBreaks;

    public float breakMulitplierSpoiler;
    public float breakMulitplierWight;
    public float breakMulitplierBreaks;


    public GameObject respawnPoint;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider Col)
    {

        if (Col.gameObject.tag == "Check Point")
        {
            respawnPoint = Col.gameObject;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            transform.position = respawnPoint.transform.position;
            transform.rotation = respawnPoint.transform.rotation;
            RespawnWraper();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rotationVector = rotationSpeedSpoiler + rotationSpeedWeight + rotationSpeedBreaks;

        rotationSpeedVector = new Vector3(0, rotationVector, 0);
        rotationSpeedReversedVector = new Vector3(0, -rotationVector, 0);

        float movementVector = movementSpeedSpoiler + movementSpeedWeight + movementSpeedBreaks;

        movementSpeedVector = new Vector3(0, 0, movementVector);

        float accelerationMulitplier = accelerationMulitplierSpoiler + accelerationMulitplierWight + accelerationMulitplierBreaks;

        float rotataionMulitplier = rotataionMulitplierSpoiler + rotationSpeedWeight + rotationSpeedBreaks;

        float breakMulitplier = breakMulitplierSpoiler + breakMulitplierWight + breakMulitplierBreaks;

        if (Input.GetKeyDown("r"))
        {
            transform.position = respawnPoint.transform.position;
            transform.rotation = respawnPoint.transform.rotation;
            RespawnWraper();
        }

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

    private void RespawnWraper()
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        acceleration = 0;
        rb.isKinematic = true;
        canMove = false;
        yield return new WaitForSeconds (2);
        canMove = true;
        rb.isKinematic = false;
    }
}
