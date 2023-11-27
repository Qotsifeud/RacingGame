using UnityEngine;

public class AIArrowHead : MonoBehaviour
{
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Face the player
            transform.LookAt(player.transform);
        }
        else
        {
            
        }
    }
}
