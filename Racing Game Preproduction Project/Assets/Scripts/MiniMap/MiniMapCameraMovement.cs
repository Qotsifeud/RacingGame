using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraMovement : MonoBehaviour
{
    public Transform target;
    public float adjustableHeight = 2.0f;
    public float zOffset = 5.0f;


    private void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("No car found");

            return;
        }

        else
        {

            Vector3 positionAboveCar = target.position + new Vector3(0, adjustableHeight, zOffset);

            // Set the position and make the UI look at the car
            transform.position = positionAboveCar;
            transform.LookAt(target);



        }
    }











}
