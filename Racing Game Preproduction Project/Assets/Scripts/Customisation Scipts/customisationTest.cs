using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class customisationTest : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject spoiler;
    [SerializeField] GameObject weight;
    bool spoilerOn = true;
    bool weightOn = true;
    private carMovement _moveScript;

    //Start is called before the first frame update
    void Start()
    {
       _moveScript = car.GetComponent<carMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")) 
        {
            spoilerOn = !spoilerOn;
            spoiler.SetActive(spoilerOn);
        }

        if (Input.GetKeyDown("v"))
        {
            weightOn = !weightOn;
            weight.SetActive(weightOn);

        }


        if (spoiler.activeInHierarchy) 
        {
            spoiler _spoilerScript = spoiler.GetComponent<spoiler>();
            _moveScript.rotationSpeed = _spoilerScript.rotationSpeed;
            _moveScript.rotationSpeedReversed = _spoilerScript.rotationSpeedReversed;
            _moveScript.rotataionMulitplier = _spoilerScript.rotationMultiplier;
        }
        else 
        {
           _moveScript.rotationSpeed = new Vector3(0, 30, 0);
           _moveScript.rotationSpeedReversed = new Vector3(0, -30, 0);
            _moveScript.rotataionMulitplier = 1;
        }

        if (weight.activeInHierarchy) 
        {
            weight _weightScript = weight.GetComponent<weight>();
             _moveScript.movement = _weightScript.Movement;
             _moveScript.accelerationMulitplier = _weightScript.accelerationMulitplier;
        }
        else 
        {
            _moveScript.movement = new Vector3(0, 0, 1);
            _moveScript.accelerationMulitplier = 1;
        }
    }
}
