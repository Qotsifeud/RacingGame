using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCustomisation : MonoBehaviour
{
    private float rotatonSpeed = 30f;
    public GameObject lightCar;
    public GameObject mediumCar;
    public GameObject heavyCar;

    public Slider speedSlider;
    public Slider accelerationSlider;
    public Slider handelingSlider;

    public float speed;
    public float acceleration;
    public float handeling;

    public float carNumber = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotatonSpeed * Time.deltaTime, 0);

        handelingSlider.value = -(accelerationSlider.value + speedSlider.value) / 2;

        speed = speedSlider.value;
        acceleration = accelerationSlider.value;
        handeling = handelingSlider.value;

        
    }

    public void ChooseCar()
    {
        if (lightCar.activeInHierarchy) 
        {
            lightCar.SetActive(false);
            mediumCar.SetActive(true);
            carNumber = 2;
        }
        else if (mediumCar.activeInHierarchy)
        {
            mediumCar.SetActive(false);
            heavyCar.SetActive(true);
            carNumber = 3;
        }
        else if (heavyCar.activeInHierarchy)
        {
            heavyCar.SetActive(false);
            lightCar.SetActive(true);
            carNumber = 1;
        }
    }

    public void ChooseCarReverse()
    {
        if (lightCar.activeInHierarchy)
        {
            lightCar.SetActive(false);
            heavyCar.SetActive(true);
            carNumber = 3;

        }
        else if (mediumCar.activeInHierarchy)
        {
            mediumCar.SetActive(false);
            lightCar.SetActive(true); 
            carNumber = 1;
        }
        else if (heavyCar.activeInHierarchy)
        {
            heavyCar.SetActive(false);
            mediumCar.SetActive(true);
            carNumber = 2;
        }
    }
}
