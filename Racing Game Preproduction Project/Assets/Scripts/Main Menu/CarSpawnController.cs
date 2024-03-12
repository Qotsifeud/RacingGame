using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnController : MonoBehaviour
{
    public GameObject carCustomiserObject;
    private CarCustomisation carCustomiser;

    public float speed;
    public float acceleration;
    public float handeling;

    // Car No. = 1: light car 2: medium car 3: heavy cars
    public float carNumber;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("CarSpawnControler");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        carCustomiser = carCustomiserObject.GetComponent<CarCustomisation>();
    }

    // Update is called once per frame
    void Update()
    {
        carNumber = carCustomiser.carNumber;

        speed = carCustomiser.speed;
        acceleration = carCustomiser.acceleration;
        handeling = carCustomiser.handeling;
    }

    //0.17 2.53 18.33 9.419 0 0
}
