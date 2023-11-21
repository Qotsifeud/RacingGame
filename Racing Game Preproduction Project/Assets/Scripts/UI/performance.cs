using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class performance : MonoBehaviour
{
    public GameObject car;
    private carMovement _carMovementScript;

    public TextMeshProUGUI speedometer;
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        _carMovementScript = car.GetComponent<carMovement>();  
    }

    // Update is called once per frame
    void Update()
    {
        speed = Convert.ToInt32(_carMovementScript.speed *  _carMovementScript.acceleration * _carMovementScript.movementVector) ;

        speedometer.text = speed.ToString();
    }
}
