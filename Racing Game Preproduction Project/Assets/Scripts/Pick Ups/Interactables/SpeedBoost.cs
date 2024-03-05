using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditorInternal.ReorderableList;

public class SpeedBoost : MonoBehaviour
{//make sure to increase acceleration not the cars boost...
    
    public int CarBoost = 10;
    public bool boostAvaiable = false;

    public GameObject boostIndicator;
    public GameObject Warning;

    private DriftController driftController;

    private void Start()
    {
        driftController = GetComponent<DriftController>();
    }

    private void Update()
    {
        if(boostAvaiable && Input.GetKeyDown("v"))
        {
            StartCoroutine(CarSpeedBoost(CarBoost));
            boostAvaiable = false;
            boostIndicator.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag == ("Medium Car"))
        {
            Destroy(other.gameObject);
            boostIndicator.SetActive(true);
            boostAvaiable = true;
        }

        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag != ("Medium Car"))
        {
            StartCoroutine(PickUpWarning());
        }
    }

    IEnumerator CarSpeedBoost(float boost)
    {
        driftController.TopSpeed += boost;

        driftController.rigidBody.velocity += transform.forward * (driftController.TopSpeed + boost);

        Debug.Log("is being used");
        yield return new WaitForSeconds(10);//wait for 10 seconds!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("is used");

        driftController.TopSpeed -= boost;
    }

    IEnumerator PickUpWarning()
    {
        Warning.SetActive(true);
        yield return new WaitForSeconds(2);
        Warning.SetActive(false);
    }
}
