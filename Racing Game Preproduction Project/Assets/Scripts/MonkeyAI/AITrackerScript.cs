using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrackerScript : MonoBehaviour
{
    private Transform targetObject;
    private RectTransform arrowRectTransform;

    private void Awake()
    {
        // Make sure there's an object with the specified tag in your scene
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("AI");

        if (objectsWithTag.Length > 0)
        {
            targetObject = objectsWithTag[0].transform; // Assuming you want the first object with the tag
        }
        else
        {
            Debug.LogError("No GameObject with the tag 'YourTag' found in the scene!");
        }

        arrowRectTransform = transform.Find("Arrow").GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (targetObject != null)
        {
            Vector3 toPoint = targetObject.position;
            Vector3 fromPoint = Camera.main.transform.position;
            fromPoint.x = 0f;

            // Get the direction vector
            Vector3 pointDirection = (toPoint - fromPoint).normalized;

            // Get the angle in degrees
            float directionAngle = Mathf.Atan2(pointDirection.y, pointDirection.x) * Mathf.Rad2Deg;

            // Adjust the angle to be positive
            directionAngle = (directionAngle + 360) % 360;

            arrowRectTransform.localEulerAngles = new Vector3(0, 0, directionAngle);
        }
    }
}





//https://www.youtube.com/watch?v=dHzeHh-3bp4

//as reference