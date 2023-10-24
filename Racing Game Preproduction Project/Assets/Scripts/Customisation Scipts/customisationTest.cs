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
            _moveScript.rotationRight = new Vector3(0, 60, 0);
            _moveScript.rotationLeft = new Vector3(0, -60, 0);
        }
        else 
        {
            _moveScript.rotationRight = new Vector3(0, 30, 0);
            _moveScript.rotationLeft = new Vector3(0, -30, 0);
        }

        if (weight.activeInHierarchy) 
        {
             _moveScript.forward = new Vector3(0, 0, 1);
             _moveScript.backward = new Vector3(0, 0, -1);
        }
        else 
        {
            _moveScript.forward = new Vector3(0, 0, 2);
            _moveScript.backward = new Vector3(0, 0, -2);
        }
    }
}
