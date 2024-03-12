using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carSpawnController;
    public CarSpawnController CSC;

    public GameObject smallCar;
    public GameObject mediumCar;
    public GameObject LargeCar;
    private void Start()
    {
        carSpawnController = GameObject.FindGameObjectWithTag("CarSpawnControler");
        CSC = carSpawnController.GetComponent<CarSpawnController>();

        if(CSC.carNumber == 1)
        {
            smallCar.SetActive(true);
        }
        else if(CSC.carNumber == 2)
        {
            mediumCar.SetActive(true);
        }
        else if(CSC.carNumber == 3)
        {
            LargeCar.SetActive(true);
        }
    }
}
