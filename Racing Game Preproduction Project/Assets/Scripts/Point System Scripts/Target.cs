using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PointCollectionTest pointCollection = other.GetComponent<PointCollectionTest>();

        if(pointCollection != null )
        {
            pointCollection.TargetCollected();
            Destroy(gameObject);
        }
    }
}
