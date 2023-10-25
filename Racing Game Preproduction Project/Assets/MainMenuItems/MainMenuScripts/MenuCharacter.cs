using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacter : MonoBehaviour
{

    private CharacterController menuCharacter;
    public float CharacterWalkSpeed = 3;


    // Start is called before the first frame update
    void Start()
    {
        menuCharacter = GetComponent<CharacterController>();//this access the character controller on the actual game object character the script is attached to
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //creating a new vector based on the horizontal and vertical imput by the WASD keys. only difference is the character doesnt change direction on y axis
        //as we dont want them flying off the groud


        menuCharacter.Move(move * Time.deltaTime * CharacterWalkSpeed);//the movement itself is calculated by the runtime multiplied by our float speed and our horizontal/ vertical movement
    }
}
