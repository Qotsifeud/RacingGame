using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditorInternal.ReorderableList;

public class SpeedBoost : MonoBehaviour
{//make sure to increase acceleration not the cars boost...
    
    public int CarBoostS = 5;
    public int CarBoostM = 10;
    public int CarBoostL = 15;
    public bool boostAvaiableSmallCar = false;
    public bool boostAvaiableMedCar = false;
    public bool boostAvaiableLargeCar = false;

    public GameObject boostIndicator;
   

    private DriftController driftController;

    private void Start()
    {
        driftController = GetComponent<DriftController>();
    }

    private void Update()
    {
        if(boostAvaiableSmallCar && Input.GetKeyDown("v"))
        {
            StartCoroutine(CarSpeedBoostS(CarBoostS));
            boostAvaiableSmallCar = false;
            boostIndicator.SetActive(false);
        }
        if (boostAvaiableMedCar && Input.GetKeyDown("v"))
        {
            StartCoroutine(CarSpeedBoostM(CarBoostM));
            boostAvaiableMedCar = false;
            boostIndicator.SetActive(false);
        }
        if (boostAvaiableLargeCar && Input.GetKeyDown("v"))
        {
            StartCoroutine(CarSpeedBoostL(CarBoostL));
            boostAvaiableLargeCar = false;
            boostIndicator.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag == ("Medium Car"))
        {
            Destroy(other.gameObject);
            boostIndicator.SetActive(true);
            boostAvaiableMedCar = true;
        }
        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag == ("Large Car"))
        {
            Destroy(other.gameObject);
            boostIndicator.SetActive(true);
            boostAvaiableLargeCar = true;
        }
        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag == ("Small Car"))
        {
            Destroy(other.gameObject);
            boostIndicator.SetActive(true);
            boostAvaiableSmallCar = true;
        }
    }

    IEnumerator CarSpeedBoostS(float sboost)
    {
        driftController.TopSpeed += sboost;

        driftController.rigidBody.velocity += transform.forward * (driftController.TopSpeed + sboost);

        Debug.Log("is being used");
        yield return new WaitForSeconds(10);//wait for 10 seconds!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("is used");

        driftController.TopSpeed -= sboost;
    }
    IEnumerator CarSpeedBoostM(float mboost)
    {
        driftController.TopSpeed += mboost;

        driftController.rigidBody.velocity += transform.forward * (driftController.TopSpeed + mboost);

        Debug.Log("is being used");
        yield return new WaitForSeconds(10);//wait for 10 seconds!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("is used");

        driftController.TopSpeed -= mboost;
    }
    IEnumerator CarSpeedBoostL(float lboost)
    {
        driftController.TopSpeed += lboost;

        driftController.rigidBody.velocity += transform.forward * (driftController.TopSpeed + lboost);

        Debug.Log("is being used");
        yield return new WaitForSeconds(10);//wait for 10 seconds!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("is used");

        driftController.TopSpeed -= lboost;
    }


}
