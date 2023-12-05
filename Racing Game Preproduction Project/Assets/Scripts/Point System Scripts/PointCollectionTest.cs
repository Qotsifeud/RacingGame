using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Unity.VisualScripting;

public class PointCollectionTest : MonoBehaviour
{
    public int NumberOfPoints { get; private set; }
    public UnityEvent<PointCollectionTest> OnPointCollected;
    public GameObject robotToRespawn;

    public void Start()
    {
        
    }

    public void TargetCollected()
    {
        NumberOfPoints++;
        OnPointCollected.Invoke(this);
    }

    public void Update()
    {
        // Checks if the monkey is active or not. If not, it starts the callMonkeyMethod coroutine.
        if(GameObject.Find("Monkey-Alien") == null)
        {
            StartCoroutine(callMonkeyMethod());
        }
    }

    // Using this as a way to wait two seconds (can be adjusted as we see fit ofcourse) before calling the monkeyRespawn script.
    public IEnumerator callMonkeyMethod()
    {
        GameObject robot = Instantiate(robotToRespawn);
        yield return new WaitForSeconds(2);
        MonkeyRespawn.monkeyRespawn(robot);
    }
}