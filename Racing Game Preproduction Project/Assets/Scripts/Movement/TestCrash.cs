using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestCrash : MonoBehaviour
{
    carMovement _carMovementScript;
    public GameObject car;
    private void Start()
    {
        _carMovementScript = car.GetComponent<carMovement>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Bumper"))
        {
            _carMovementScript.canMove = false;
            _carMovementScript.speed = 0;
            _carMovementScript.acceleration = 0;
            StartCoroutine(CrashTimer());
            Debug.Log("CrashBumperHasCollided");
        }

        else
        {
            
        }
    }


    IEnumerator CrashTimer()
    {
        yield return new WaitForSeconds(0.1f);
        _carMovementScript.canMove = false;
        _carMovementScript.speed = 3;
        _carMovementScript.acceleration = -1f;
        StartCoroutine(CarReset());
    }

    IEnumerator CarReset()
    {
        yield return new WaitForSeconds(0.4f);
        _carMovementScript.canMove = true;
        _carMovementScript.speed = 17;
        _carMovementScript.acceleration = 0f;
    }









}
