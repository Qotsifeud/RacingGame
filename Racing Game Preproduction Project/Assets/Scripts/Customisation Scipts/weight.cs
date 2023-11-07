using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weight : MonoBehaviour
{
    public Vector3 Movement = new Vector3(0, 0, 0.5f);
    public float accelerationMulitplier = 0.5f;
    public GameObject car;

    private void Update()
    {
        customisationTest _customisationScript = car.GetComponent<customisationTest>();

        _customisationScript._weightScript = this;
    }


    //float speed;
    //float accelerationl;
    //float handling;
    //float breaks;
    //float wait;
    //float taraction;
}
