using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject SpawnLight;
    public GameObject respawnPoint;
    public GameObject car;
    Rigidbody rb;
    //carMovement _carMovementScript;

    private void Start()
    {
        SpawnLight.SetActive(false);
        //_carMovementScript = car.GetComponent<carMovement>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            transform.position = respawnPoint.transform.position;
            transform.rotation = respawnPoint.transform.rotation;
            RespawnWraper();
        }
    }

    void OnTriggerEnter(Collider Col)
    {

        if (Col.gameObject.tag == "Check Point")
        {
            respawnPoint = Col.gameObject;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            transform.position = respawnPoint.transform.position;
            transform.rotation = respawnPoint.transform.rotation;
            RespawnWraper();
        }
    }

    private void RespawnWraper()
    {
       


        StartCoroutine(Respawn());

    }

    private IEnumerator Respawn()
    {
        SpawnLight.SetActive(true);
        //_carMovementScript.acceleration = 0;
        rb.isKinematic = true;
        //_carMovementScript.canMove = false;
        yield return new WaitForSeconds(0.5f);
        //_carMovementScript.canMove = true;
        rb.isKinematic = false;
        StartCoroutine(RespawnLight());


    }

    IEnumerator RespawnLight()
    {
        yield return new WaitForSeconds(1f);
        SpawnLight.SetActive(false);

    }
}
