using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{//make sure to increase acceleration not the cars boost...
    public float smallCarBoost = 5;
    public float mediumCarBoost = 10;
    public float largeCarBoost = 15;
    public float BoostTimer = 10;//10 seconds?



    //resetting the values back to the default after the boost
    private int SmallCarDefault;
    private int mediumCarDefault;
    private int largeCarDefault;    
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Small Car"))
        {
            other.gameObject.GetComponent<DriftController>().Accel = smallCarBoost;
            Destroy(this.gameObject);
            StartCoroutine(SpeedBoostTimer());//waits 10 seconds before resetting the acceleration to default

        }

        if (other.gameObject.tag == ("Medium Car"))
        {
            other.gameObject.GetComponent<DriftController>().Accel = mediumCarBoost;
            Destroy(this.gameObject);
            StartCoroutine(SpeedBoostTimer());//waits 10 seconds before resetting the acceleration to default

        }
        
        if (other.gameObject.tag == ("Large Car"))
        {

            other.gameObject.GetComponent<DriftController>().Accel = largeCarBoost;
            Destroy(this.gameObject);
            StartCoroutine(SpeedBoostTimer());//waits 10 seconds before resetting the acceleration to default

        }



    }


    IEnumerator SpeedBoostTimer()
    {
        yield return new WaitForSeconds(BoostTimer);//wait for 10 seconds
        
    }












}
