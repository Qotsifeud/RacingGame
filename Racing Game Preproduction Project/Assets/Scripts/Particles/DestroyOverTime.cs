using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetime;//timer for destroying the particle system.



    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);//this destroys the game object over a set amount of time, this is public and set in unity

    }//end of update



}//end of class
