using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PointCollectionTest : MonoBehaviour
{
    public int NumberOfPoints { get; private set; }
    public UnityEvent<PointCollectionTest> OnPointCollected;

    public void TargetCollected()
    {
        NumberOfPoints++;
        OnPointCollected.Invoke(this);
    }
}