using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PointCollectionTest : MonoBehaviour
{
    public int NumberOfPoints { get; private set; }
    public UnityEvent<PointCollectionTest> OnPointCollected;
    public GameObject monkalien;

    public void Start()
    {
        monkalien = GameObject.Find("Monkey-Alien").gameObject;
    }

    public void TargetCollected()
    {
        NumberOfPoints++;
        OnPointCollected.Invoke(this);
    }

    public void Update()
    {
        // Checks if the monkey is active or not. If not, it starts the callMonkeyMethod coroutine.
        if(monkalien.activeInHierarchy == false)
        {
            StartCoroutine(callMonkeyMethod());
        }
    }

    // Using this as a way to wait two seconds (can be adjusted as we see fit ofcourse) before calling the monkeyRespawn script.
    public IEnumerator callMonkeyMethod()
    {
        yield return new WaitForSeconds(2);
     //   MonkeyRespawn.monkeyRespawn(monkalien);
    }
}