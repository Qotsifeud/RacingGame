using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditorInternal.ReorderableList;

public class SpeedBoost : MonoBehaviour
{//make sure to increase acceleration not the cars boost...
    public int smallCarBoost = 90;
    public int mediumCarBoost = 80;
    public int largeCarBoost = 70;

    public bool BoostActive = false;


    //resetting the values back to the default after the boost
    public int SmallCarDefault = 80;
    public int mediumCarDefault = 70;
    public int largeCarDefault = 60;


   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag == ("Small Car"))
        {
            Destroy(other.gameObject);
            StartCoroutine(SpeedBoostTimerSmallCar(SmallCarDefault, smallCarBoost));
        }

        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag == ("Medium Car"))
        {
            Destroy(other.gameObject);
            StartCoroutine(SpeedBoostTimerSmallCar(mediumCarDefault, mediumCarBoost));

        }
        
        if (other.gameObject.tag == ("SpeedBooster") && this.gameObject.tag == ("Large Car"))
        {
            Destroy(other.gameObject);
            StartCoroutine(SpeedBoostTimerSmallCar(largeCarDefault, largeCarBoost));
        }



    }








    //private void Wraper()
    //{
    //    StartCoroutine(SpeedBoostTimer());
    //}


    IEnumerator SpeedBoostTimerSmallCar(float defaut, float boost)
    {

        this.gameObject.GetComponent<DriftController>().TopSpeed = boost;

        Debug.Log("is being used");
        yield return new WaitForSeconds(10);//wait for 10 seconds!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("is used");



        this.gameObject.GetComponent<DriftController>().TopSpeed = defaut;


    }

    IEnumerator SpeedBoostTimerMediumCar(float defaut, float boost)
    {

        this.gameObject.GetComponent<DriftController>().TopSpeed = boost;

        Debug.Log("is being used");
        yield return new WaitForSeconds(10);//wait for 10 seconds!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("is used");



        this.gameObject.GetComponent<DriftController>().TopSpeed = defaut;


    }

    IEnumerator SpeedBoostTimerLargeCar(float defaut, float boost)
    {

        this.gameObject.GetComponent<DriftController>().TopSpeed = boost;

        Debug.Log("is being used");
        yield return new WaitForSeconds(10);//wait for 10 seconds!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("is used");



        this.gameObject.GetComponent<DriftController>().TopSpeed = defaut;


    }








}
