using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class customisationTest : MonoBehaviour
{
    [SerializeField] GameObject car;

    [SerializeField] GameObject spoiler1;
    [SerializeField] GameObject spoiler2;
    [SerializeField] GameObject spoiler3;

    [SerializeField] GameObject weight1;
    [SerializeField] GameObject weight2;
    [SerializeField] GameObject weight3;

    [SerializeField] GameObject breaks1;
    [SerializeField] GameObject breaks2;
    [SerializeField] GameObject breaks3;



    bool spoilerOn = true;
    bool weightOn = true;
    private carMovement _moveScript;
    public spoiler _spoilerScript;
    public weight _weightScript;
    public breaks _breakScript;


    //Start is called before the first frame update
    void Start()
    {
       _moveScript = car.GetComponent<carMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")) // key to switch active spoiler 
        {
            if(spoiler1.activeInHierarchy)
            {
                spoiler1.SetActive(false);
                spoiler2.SetActive(true);
            }
            else if(spoiler2.activeInHierarchy)
            {
                spoiler2.SetActive(false);
                spoiler3.SetActive(true);
            }
            else if(spoiler3.activeInHierarchy)
            {
                spoiler3.SetActive(false);
                spoiler1.SetActive(true);
            }
        }

        if (Input.GetKeyDown("v")) // key to switch active custom weight
        {
            if (weight1.activeInHierarchy)
            {
                weight1.SetActive(false);
                weight2.SetActive(true);
            }
            else if (weight2.activeInHierarchy)
            {
                weight2.SetActive(false);
                weight3.SetActive(true);
            }
            else if (weight3.activeInHierarchy)
            {
                weight3.SetActive(false);
                weight1.SetActive(true);
            }
        }

        if (Input.GetKeyDown("x")) // key to switch active custom air breaks 
        { 
            if(breaks1.activeInHierarchy)
            {
                breaks1.SetActive(false);
                breaks2.SetActive(true);
            }
            else if (breaks2.activeInHierarchy)
            {
                breaks2.SetActive(false);
                breaks3.SetActive(true);
            }
            else if (breaks3.activeInHierarchy)
            {
                breaks3.SetActive(false);
                breaks1.SetActive(true);
            }
        }
   
        // updates the movement script with relevent modiffiers from the spoiler 
        _moveScript.rotationSpeed = _spoilerScript.rotationSpeed;
        _moveScript.rotationSpeedReversed = _spoilerScript.rotationSpeedReversed;
        _moveScript.rotataionMulitplier = _spoilerScript.rotationMultiplier;

        // same for the weight
        _moveScript.movement = _weightScript.Movement;
        _moveScript.accelerationMulitplier = _weightScript.accelerationMulitplier;

        // same for the breaks 
        _moveScript.breakMulitplier = _breakScript.breakMulitplier;

    }
}
