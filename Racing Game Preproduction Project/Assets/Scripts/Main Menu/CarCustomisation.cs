using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarCustomisation : MonoBehaviour
{
    private float rotatonSpeed = 30f;
    public GameObject lightCar;
    public GameObject mediumCar;
    public GameObject heavyCar;

    public GameObject lightCarInfo;
    public GameObject mediumCarInfo;
    public GameObject heavyCarInfo;

    public float speed;
    public float acceleration;
    public float handeling;

    public float carNumber = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotatonSpeed * Time.deltaTime, 0);

        
    }

    public void ChooseCar()
    {
        if (lightCar.activeInHierarchy) 
        {

            lightCar.SetActive(false);
            lightCarInfo.SetActive(false);
            mediumCar.SetActive(true);
            mediumCarInfo.SetActive(true);
            heavyCar.SetActive(false);
            heavyCarInfo.SetActive(false);
            carNumber = 2;


        }
        else if (mediumCar.activeInHierarchy)
        {
            lightCar.SetActive(false);
            lightCarInfo.SetActive(false);
            mediumCar.SetActive(false);
            mediumCarInfo.SetActive(false);
            heavyCar.SetActive(true);
            heavyCarInfo.SetActive(true);
            carNumber = 3;
        }
        else if (heavyCar.activeInHierarchy)
        {
            lightCar.SetActive(true);
            lightCarInfo.SetActive(true);
            mediumCar.SetActive(false);
            mediumCarInfo.SetActive(false);
            heavyCar.SetActive(false);
            heavyCarInfo.SetActive(false);
            carNumber = 1;
        }
    }

    public void ChooseCarReverse()
    {
        if (lightCar.activeInHierarchy)
        {
            lightCar.SetActive(false);
            lightCarInfo.SetActive(false);
            mediumCar.SetActive(false);
            mediumCarInfo.SetActive(false);
            heavyCar.SetActive(true);
            heavyCarInfo.SetActive(true);
            carNumber = 3;
        }
        else if (heavyCar.activeInHierarchy)
        {
            lightCar.SetActive(false);
            lightCarInfo.SetActive(false);
            mediumCar.SetActive(true);
            mediumCarInfo.SetActive(true);
            heavyCar.SetActive(false);
            heavyCarInfo.SetActive(false);
            carNumber = 2;
        }
        else if (mediumCar.activeInHierarchy)
        {
            lightCar.SetActive(true);
            lightCarInfo.SetActive(true);
            mediumCar.SetActive(false);
            mediumCarInfo.SetActive(false);
            heavyCar.SetActive(false);
            heavyCarInfo.SetActive(false);
            carNumber = 1;
        }

    }
}
