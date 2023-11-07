using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spoiler : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 60, 0);
    public Vector3 rotationSpeedReversed = new Vector3(0, -60, 0);
    public float rotationMultiplier = 2f;
    public GameObject car;

    private void Update()
    {
        customisationTest _customisationScript = car.GetComponent<customisationTest>();

        _customisationScript._spoilerScript = this;
    }
}
