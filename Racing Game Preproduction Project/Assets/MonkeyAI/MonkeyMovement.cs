using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MonkeyMovement : MonoBehaviour
{
    //Once navmeshe is installed i can make the monkeys movements more advance as reight not its just moving around randomly.
    public float MonkeySpeed = 2.0f;
    private Rigidbody Mbody;//this game objects rigidbody
    void Start()
    {
        Mbody = GetComponent<Rigidbody>();
    }

   
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Obstacle"))
        {
            Vector3 resetLocation = new Vector3(Random.Range(-2.0f, 2f), 0.0f, Random.Range(-2.0f, 2f));
            Mbody.AddForce(-resetLocation * MonkeySpeed);
        }
    }

  





    void FixedUpdate()
    {
        float MoveX = Random.Range(-2.0f, 2f);
        float MoveZ = Random.Range(-2.0f, 2f);
        Vector3 newLocation = new Vector3(MoveX, 0.0f, MoveZ);
        Mbody.AddForce(newLocation * MonkeySpeed);//moves the monkeys rigidbody towards the movement to the new location at monkey speed.
    }
}




