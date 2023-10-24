using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weight : MonoBehaviour
{
    [SerializeField] public Vector3 forward = new Vector3(0, 0, 1);
    [SerializeField] public Vector3 backward = new Vector3(0, 0, -1);

    float speed;
    float accelerationl;
    float handling;
    float breaks;
    float wait;
    float taraction;
}
