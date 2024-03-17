using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject go;

    public DriftController driftController;
    public timer gameClock;
  


    private void Start()
    {
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);
        go.SetActive(false);

     
        driftController = FindObjectOfType<DriftController>();//finds an object in the scene with the drift controller attached

        StartCoroutine(startTimerCountdown());
        timer.startTimer = false;//default to off at the start of the race
      //  DriftController.canStartDriving = false;//default to off
        driftController.GetComponent<DriftController>().enabled = false;

    }



    IEnumerator startTimerCountdown()
    {

        three.SetActive(true);
        yield return new WaitForSeconds(1);
        three.SetActive(false);
        Debug.Log("three");

        two.SetActive(true);
        yield return new WaitForSeconds(1);
        two.SetActive(false);
        Debug.Log("two");

        one.SetActive(true);
        yield return new WaitForSeconds(1);
        one.SetActive(false);
        Debug.Log("one");

        go.SetActive(true);
        yield return new WaitForSeconds(1);
        go.SetActive(false);
        timer.startTimer = true;//setting the time to true at the start of the race
       
        Debug.Log("GO!");
     
        driftController.GetComponent<DriftController>().enabled = true;
    }



























}
