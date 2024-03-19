using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour
{
    private Rigidbody lorryBody;


    private void Start()
    {
        lorryBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        lorryBody.AddForce(lorryBody.transform.forward, ForceMode.Force);
        StartCoroutine(DestroyOnSecond());

    }

    IEnumerator DestroyOnSecond()
    {
        yield return new WaitForSeconds(8);

        Destroy(this.gameObject);
    }



}
