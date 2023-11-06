using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform car;

    public Vector3 rotationSpeed = new Vector3(0, 30, 0);
    public Vector3 rotationSpeedReversed = new Vector3(0, -30, 0);
    public float rotation;


    public float speed = 17;
    public Vector3 movement = new Vector3(0, 0, 1);
    public float acceleration;

    public float accelerationMulitplier = 1;
    public float rotataionMulitplier = 1;
    public float breakMulitplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) // forward Acceleration
        {
            acceleration += Time.deltaTime * accelerationMulitplier;

            if (acceleration > 1)
            {
                acceleration = 1;
            }

            transform.Translate(movement * speed * Time.deltaTime * acceleration);

        }
        else if (Input.GetKey("s")) // backwards acceleration
        {
            acceleration -= Time.deltaTime * accelerationMulitplier;

            if (acceleration < -1)
            {
                acceleration = -1;
            }
            transform.Translate(movement * speed * Time.deltaTime * acceleration);


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
            transform.Translate(movement * speed * Time.deltaTime * acceleration);

        }

        if (acceleration > 0 || acceleration < 0) // set so car wont trun without forward momentum
        {
            if (Input.GetKey("d")) // right turns
            {
                rotation += Time.deltaTime * rotataionMulitplier;

                if (rotation > 1)
                {
                    rotation = 1;
                }

                if (acceleration > 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (acceleration < 0) // reverse rotation for driving backwards 
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
            else if (Input.GetKey("a")) // left turns
            {
                rotation -= Time.deltaTime * rotataionMulitplier;

                if (rotation < -1)
                {
                    rotation = -1;
                }

                if (acceleration > 0) 
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (acceleration < 0) // reverse rotation for driving backwards 
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
            else // resets strearing position when not activley stearing
            {
                if (rotation <= 1 && rotation > 0.25)
                {
                    rotation -= Time.deltaTime * rotataionMulitplier;
                }
                else if (rotation >= -1 && rotation < -0.25)
                {
                    rotation += Time.deltaTime * rotataionMulitplier;

                }
                else if (rotation < 0.25 || rotation > -0.25)
                {
                    rotation = 0;
                }

                if (acceleration > 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (acceleration < 0) // reverse rotation for drifting backwards 
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
        }
    }
}
