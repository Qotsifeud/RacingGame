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

    [SerializeField]float speed;
    [SerializeField]float acceleration;
    [SerializeField]float handeling;

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
        }
        else if (mediumCar.activeInHierarchy)
        {
            mediumCar.SetActive(false);
            heavyCar.SetActive(true);
        }
        else if (heavyCar.activeInHierarchy)
        {
            heavyCar.SetActive(false);
            lightCar.SetActive(true);
        }
    }

    public void ChooseCarReverse()
    {
        if (lightCar.activeInHierarchy)
        {
            lightCar.SetActive(false);
            heavyCar.SetActive(true);

        }
        else if (mediumCar.activeInHierarchy)
        {
            mediumCar.SetActive(false);
            lightCar.SetActive(true);

        }
        else if (heavyCar.activeInHierarchy)
        {
            heavyCar.SetActive(false);
            mediumCar.SetActive(true);
        }
    }
}
