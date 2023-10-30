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
            //_moveScript.rotationRight = _spoilerScript.rotationRight;
            //_moveScript.rotationLeft = _spoilerScript.rotationLeft;
        }
        else 
        {
           // _moveScript.rotationRight = new Vector3(0, 30, 0);
           //_moveScript.rotationLeft = new Vector3(0, -30, 0);
        }

        if (weight.activeInHierarchy) 
        {
            weight _weightScript = weight.GetComponent<weight>();
             //_moveScript.forward = _weightScript.forward;
             //_moveScript.backward = _weightScript.backward;
        }
        else 
        {
            //_moveScript.forward = new Vector3(0, 0, 2);
            //_moveScript.backward = new Vector3(0, 0, -2);
        }
    }
}
