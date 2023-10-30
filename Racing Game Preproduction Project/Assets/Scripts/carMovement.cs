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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            acceleration += Time.deltaTime;

            if (acceleration > 1)
            {
                acceleration = 1;
            }

            transform.Translate(movement * speed * Time.deltaTime * acceleration);

        }
        else if (Input.GetKey("s"))
        {
            acceleration -= Time.deltaTime;

            if (acceleration < -1)
            {
                acceleration = -1;
            }
            transform.Translate(movement * speed * Time.deltaTime * acceleration);


        }
        else 
        {
            if (acceleration <= 1 && acceleration > 0.25)
            {
                acceleration -= Time.deltaTime;
            }
            else if (acceleration >= -1 && acceleration < -0.25)
            {
                acceleration += Time.deltaTime;
            }
            else if (acceleration < 0.25 || acceleration > -0.25)
            {
                acceleration = 0;
            }
            transform.Translate(movement * speed * Time.deltaTime * acceleration);

        }

        if (acceleration > 0 || acceleration < 0)
        {
            if (Input.GetKey("d"))
            {
                rotation += Time.deltaTime;

                if (rotation > 1)
                {
                    rotation = 1;
                }

                if (acceleration > 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (acceleration < 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
            else if (Input.GetKey("a"))
            {
                rotation -= Time.deltaTime;

                if (rotation < -1)
                {
                    rotation = -1;
                }

                if (acceleration > 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (acceleration < 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
            else
            {
                if (rotation <= 1 && rotation > 0.25)
                {
                    rotation -= Time.deltaTime;
                }
                else if (rotation >= -1 && rotation < -0.25)
                {
                    rotation += Time.deltaTime;

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
                else if (acceleration < 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(rotationSpeedReversed * Time.deltaTime * rotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
        }
    }
}
