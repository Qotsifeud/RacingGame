using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform car;
    public float speed = 17;

    public Vector3 ySpeed = new Vector3(0, 30, 0);
    public Vector3 ySpeedReversed = new Vector3(0, -30, 0);
    public float rotationAccelerationLeft;
    public float rotationAccelerationRight;
    public float yRotation;

    public Vector3 zMovement = new Vector3(0, 0, 1);
    public float forwardAcceleration;
    public float backwardAcceleration;
    public float zAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            zAcceleration += Time.deltaTime;

            if (zAcceleration > 1)
            {
                zAcceleration = 1;
            }

            transform.Translate(zMovement * speed * Time.deltaTime * zAcceleration);

        }
        else if (Input.GetKey("s"))
        {
            zAcceleration -= Time.deltaTime;

            if (zAcceleration < -1)
            {
                zAcceleration = -1;
            }
            transform.Translate(zMovement * speed * Time.deltaTime * zAcceleration);


        }
        else 
        {
            if (zAcceleration <= 1 && zAcceleration > 0.25)
            {
                zAcceleration -= Time.deltaTime;
            }
            else if (zAcceleration >= -1 && zAcceleration < -0.25)
            {
                zAcceleration += Time.deltaTime;
            }
            else if (zAcceleration < 0.25 || zAcceleration > -0.25)
            {
                zAcceleration = 0;
            }
            transform.Translate(zMovement * speed * Time.deltaTime * zAcceleration);

        }

        if (zAcceleration > 0 || zAcceleration < 0)
        {
            if (Input.GetKey("d"))
            {
                yRotation += Time.deltaTime;

                if (yRotation > 1)
                {
                    yRotation = 1;
                }

                if (zAcceleration > 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(ySpeed * Time.deltaTime * yRotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (zAcceleration < 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(ySpeedReversed * Time.deltaTime * yRotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
            else if (Input.GetKey("a"))
            {
                yRotation -= Time.deltaTime;

                if (yRotation < -1)
                {
                    yRotation = -1;
                }

                if (zAcceleration > 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(ySpeed * Time.deltaTime * yRotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (zAcceleration < 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(ySpeedReversed * Time.deltaTime * yRotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
            else
            {
                if (yRotation <= 1 && yRotation > 0.25)
                {
                    yRotation -= Time.deltaTime;
                }
                else if (yRotation >= -1 && yRotation < -0.25)
                {
                    yRotation += Time.deltaTime;

                }
                else if (yRotation < 0.25 || yRotation > -0.25)
                {
                    yRotation = 0;
                }

                if (zAcceleration > 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(ySpeed * Time.deltaTime * yRotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (zAcceleration < 0)
                {
                    Quaternion deltaRotation = Quaternion.Euler(ySpeedReversed * Time.deltaTime * yRotation);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }

            }
        }
    }
}
