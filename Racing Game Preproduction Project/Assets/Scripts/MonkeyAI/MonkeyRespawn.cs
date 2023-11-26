using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyRespawn : MonoBehaviour
{
    public GameObject playerRespawnPoint;
    public static GameObject respawnPoint;
    int randomRespawnNumber;
    GameObject[] resPoints;

    public void Start()
    {
        // Reads in the number of checkpoints placed on a map at any time and adjusts the array to an appropriate size to store them.
        //resPoints = new GameObject[GameObject.Find("Check Points").transform.childCount];

        resPoints = new GameObject[GameObject.Find("Check Points").transform.childCount];

        playerRespawnPoint = GameObject.Find("Goblin Car Mk .4").GetComponent<respawn>().respawnPoint;

        for (int i = 0; i < resPoints.Length; i++)
        {
            if (i == 0)
            {
                // Assigns position 0 in the array to Check Point One.
                resPoints[i] = GameObject.Find("Check Point 1");
            }
            else
            {
                // Assigns every other Check Point to a position.
                resPoints[i] = GameObject.Find("Check Point " + (i + 1));
            }
        }

        respawnPoint = resPoints[Random.Range(0, resPoints.Length)];

        if(respawnPoint == playerRespawnPoint)
        {
            do
            {
                respawnPoint = resPoints[Random.Range(0, resPoints.Length)];
            } while (respawnPoint == playerRespawnPoint);
        }
        

        // Any time the Monkey/Alien (Monkey-lien?) becomes active and this script starts, it spawns at a random checkpoint.
        //respawnPoint = resPoints[Random.Range(0, resPoints.Length)];

    }

    // Using this method as a way to call to this script outside of it and set the monkey to active again in a position based on the random checkpoints.
    public static void monkeyRespawn(GameObject gameObject)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = respawnPoint.transform.position;
        gameObject.transform.rotation = respawnPoint.transform.rotation;
    }
}
