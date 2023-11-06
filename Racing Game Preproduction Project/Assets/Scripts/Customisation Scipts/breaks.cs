using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaks : MonoBehaviour
{

    public float breakMulitplier = 1f;
    public GameObject car;

    private void Update()
    {
        customisationTest _customisationScript = car.GetComponent<customisationTest>();

        _customisationScript._breakScript = this;
    }
}
