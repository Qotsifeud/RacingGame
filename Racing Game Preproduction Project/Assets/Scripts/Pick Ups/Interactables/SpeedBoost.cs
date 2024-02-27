using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditorInternal.ReorderableList;

public class SpeedBoost : MonoBehaviour
{
    public float boost = 10;

    public bool haveSpeedBoost = false;
    public float boostTime = 5f;
    public GameObject boostIndicator;
    public GameObject warningIndicator;

    private DriftController driftController;
    private Rigidbody rb;
    private void Start()
    {
        driftController = GetComponent<DriftController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(haveSpeedBoost)
        {
            boostIndicator.SetActive(true);

            if(Input.GetKeyDown("v"))
            {
                StartCoroutine(Boost(boost));
                haveSpeedBoost = false;
            }
        }
        else
        {
            boostIndicator.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag == ("Medium Car"))
        {
            Destroy(other.gameObject);
            haveSpeedBoost = true;
            
        }
        else if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag != ("Medium Car"))
        {
            StartCoroutine(Warning());
        }
    }

    IEnumerator Boost(float boost)
    {
        driftController.TopSpeed += boost;
        rb.velocity += transform.forward * (driftController.TopSpeed + boost);

        Debug.Log("is being used");
        yield return new WaitForSeconds(boostTime);
        Debug.Log("is used");

        driftController.TopSpeed -= boost;
    }

    IEnumerator Warning()
    {
        warningIndicator.SetActive(true);
        yield return new WaitForSeconds(2);
        warningIndicator.SetActive(false);
    }
}
