using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AIspawner : MonoBehaviour
{
   
    public List<GameObject> AIPrefabs = new List<GameObject>();
    public static int NumberOfPrefabs = 10;




    void Start()
    {
        NumberOfPrefabs = AIPrefabs.Count;//counting the number of prefabs in the list of prefab AIs
    }

    // Update is called once per frame
    void Update()
    {
        if(NumberOfPrefabs <= 0)
        {
            GameOver();
        }
        
    }

    void GameOver()
    {
        Debug.Log("The game is complete");
    }


 

}
