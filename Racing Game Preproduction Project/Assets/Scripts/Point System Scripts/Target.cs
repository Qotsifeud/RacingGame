using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Stopwatch timer = new Stopwatch();
    private void OnTriggerEnter(Collider other)
    {
        PointCollectionTest pointCollection = other.GetComponent<PointCollectionTest>();

        if(pointCollection != null )
        {
            pointCollection.TargetCollected();
            gameObject.SetActive(false);
            

            
        }
    }
}
