using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endOfRaceCam : MonoBehaviour
{
    public Transform finalPosition;
    public float camMoveSpeed = 8f;
    public float camRotSpeed = 4f;

    private void Update()
    {
        if (finalPosition != null)
        {
            Vector3 direction = finalPosition.position - transform.position;
            transform.Translate(direction.normalized * camMoveSpeed * Time.deltaTime);

            if (direction.magnitude < 0.1f)
            {
                transform.position = finalPosition.position;
                Quaternion targetRotation = Quaternion.LookRotation(finalPosition.forward, finalPosition.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, camRotSpeed * Time.deltaTime);
                finalPosition = null;
            }
        }
    }
}