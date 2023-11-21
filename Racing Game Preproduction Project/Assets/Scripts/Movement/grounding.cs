using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounding : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] private bool isGrounded = true; 

    // Update is called once per frame
    void Update()
    {
        if(!isGrounded) 
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else if (isGrounded)
        {
            rb.constraints = RigidbodyConstraints.None;
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
