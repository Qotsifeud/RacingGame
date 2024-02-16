using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCounter : MonoBehaviour
{

    
    public int currentNumberOfLaps = 0;
    public int maxLaps = 3;

    public GameObject backBlocker;
    public GameObject frontBlocker;
    public bool frontChecker;
    public bool backChecker;
    

    public void Start()
    {

        backChecker = true;
        frontChecker = false;

    }



    public void Update()
    {

        if (currentNumberOfLaps > maxLaps)
        {

            //end game
            Debug.Log("i finished the laps");

        }

        if (!frontChecker)
        {
            frontBlocker.SetActive(false);//so they cant continue the second/3rd lap
        }


        if (frontChecker)
        {
            frontBlocker.SetActive(true);//so they cant continue the second/3rd lap
        }

        if (!backChecker)
        {
            backBlocker.SetActive(false);
        }
        if (backChecker)
        {
            backBlocker.SetActive(true);
        }
      

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("StartAndFinishLine"))
        {
           
            frontChecker = false;
            


        }


    }




    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == ("StartAndFinishLine Car"))
        {
            frontChecker = true;
            backChecker = false;
            currentNumberOfLaps += 1;//incramented

        }


    }










}
