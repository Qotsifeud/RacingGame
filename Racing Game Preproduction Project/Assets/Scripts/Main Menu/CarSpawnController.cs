using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnController : MonoBehaviour
{
    public GameObject carCustomiserObject;
    private CarCustomisation carCustomiser;

    [SerializeField]float speed;
    [SerializeField]float acceleration;
    [SerializeField]float handeling;

    [SerializeField]float carNumber;

    // Start is called before the first frame update
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
}
