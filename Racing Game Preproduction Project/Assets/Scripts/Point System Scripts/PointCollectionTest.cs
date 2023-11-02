using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollectionTest : MonoBehaviour
{
    public int NumberOfPoints { get; private set; }

    public void TargetCollected()
    {
        NumberOfPoints++;
    }
}
