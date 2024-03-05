using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{

    public Image three;
    public Image two;
    public Image one;
    public Image go;

    public DriftController driftController;
    public timer gameClock;


    private void Start()
    {
        three.enabled = false; two.enabled = false; one.enabled = false; go.enabled = false;



        driftController = FindObjectOfType<DriftController>();//finds an object in the scene with the drift controller attached

        StartCoroutine(startTimerCountdown());
        timer.startTimer = false;//default to off at the start of the race
        DriftController.canStartDriving = false;//default to off

    }



    IEnumerator startTimerCountdown()
    {

        three.enabled = true;
        yield return new WaitForSeconds(1);
        three.enabled = false;
        Debug.Log("three");

        two.enabled = true;
        yield return new WaitForSeconds(1);
        two.enabled = false;
        Debug.Log("two");

        one.enabled = true;
        yield return new WaitForSeconds(1);
        one.enabled = false;
        Debug.Log("one");

        go.enabled = true;
        yield return new WaitForSeconds(1);
        go.enabled = false;
        timer.startTimer = true;//setting the time to true at the start of the race
        DriftController.canStartDriving = true;//setting the driving to true after the countdown
        Debug.Log("GO!");
    }



























}
