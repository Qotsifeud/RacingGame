using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MonkeyMovement : MonoBehaviour
{

    public NavMeshAgent monkey;//this is reference to the navmesh agent attached to the monkey game object that this script is attached to
    public Transform Player;//reference to the player transform, this will be used when creating the fleeing code.
    public LayerMask IsPlayer, IsMap;
    private Vector3 RandomLocation;//new vector 3 for the monkey to randomly go to
    private Vector3 RandomBumpLocation;
    private bool RandomLocationChosen;
    private bool RandomBumperLocationChosen;
    public float RangeOfRandomLocation;
    public float RangeOfRandomBumperFleeing;


    public float WanderSpeed = 5;
    public float FleeingSpeed = 10;

    private bool playerIsClose;//this bool will be set aflse at the start of the game unless the player is within chasing distance of the monkey, triggering monkey to run away/ flee
    public float distanceFromPlayer = 5; // this float detects if the player is within chasing distance of the monkey [default to 5]
    private bool BumperCollided;
    public GameObject MonkeyModel;
    public GameObject AlienModel;
    private float ModelSelector;







    private void Awake()
    {

        Player = GameObject.FindGameObjectWithTag("Player").transform;//assigns the player transform to the game object in the scene with the tage Player, which will be our players vehicle
        monkey = GetComponent<NavMeshAgent>();//this assigns the navmesh agent on our monkey game object to the monkey variable for the  nav mesh agent

    }




     void Start()
    {
        playerIsClose = false;//setting the bool to false as the first monkey wont be near the player at the start of the game
        BumperCollided = false;
        ModelSelector = Random.Range(0f, 11f);//randomly selects which model to display e.g monkey or alien


        //this just randomly chooses which model to use at the start of the game
        if (ModelSelector <= 5)
        {
            MonkeyModel.SetActive(true);
            AlienModel.SetActive(false);
        }

        if(ModelSelector >= 6)
        {
            MonkeyModel.SetActive(false);
            AlienModel.SetActive(true);
        }




    }




     void Update()
    {
        playerIsClose = Physics.CheckSphere(transform.position, distanceFromPlayer, IsPlayer);

        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer < distanceFromPlayer)
        {
            playerIsClose = true;
        }

        if (distanceToPlayer > distanceFromPlayer)
        {
            playerIsClose = false;
        }


        if (!playerIsClose && !BumperCollided)
        {
            //if the player is not close to the monkey monkey wanders
            Wandering();//calling the wander function

        }



        if(playerIsClose && !BumperCollided)
        {
            //if the player is too close to the monkey then the monkey will flee from the player
            Fleeing();//calling the fleeing function
            RandomLocationChosen = false;//resetting  the random location so that if the player stays in the previous location chosem by the monkey it wont keep trying to return  to that same spot
            RandomBumperLocationChosen = false;
        }


      
        else if (BumperCollided)//if bool triggered change movement to bumper movement
        {
            
            BumperMovement();
            RandomLocationChosen = false;//resetting  the random location so that if the player stays in the previous location chosem by the monkey it wont keep trying to return  to that same spot
           
        }

     

        else
        {
            BumperCollided = false;
        }

     

    }


     public void OnCollisionEnter(Collision collision)//collision triggers bool
    {
        if (collision.gameObject.tag == "Bumper")
        {

            BumperCollided = true;
            Debug.Log("Collision true");
            
        }
        else
        {
            BumperCollided = false;
        }
    }

  




    private void Wandering()//funciton for wandering around the map
    {

        monkey.speed = WanderSpeed;


        if (!RandomLocationChosen) //if the location for the monkey to move to have not been set then generate a random location
        {
            RandomLocationGenerator();//calling the fucntion to generate a new random location for the monkey
        }

        if (RandomLocationChosen)
        {
            monkey.SetDestination(RandomLocation);//sets the agent to move towards the random location if the random locationchosen bool is set to true
        }//if the raycast below doent detect ground on the map then itll look for another random location that is on  the ground before setting this bool to true and moving the monkey to the new location on the map.

        Vector3 distanctToRandomLocation = transform.position - RandomLocation;//this new variable calculated the distance between the monkey and the random location generated

        if(distanctToRandomLocation.magnitude < 1f)//if the distance calculated is lessthan 1 that meand the monkey has reached that randomly generated location
        {
            RandomLocationChosen = false;//as they have reached their destination the bool is set to false resetting and regenerating a new random location for the monkey to move towards
        }

        

    }


    private void BumperMovement()
    {

        monkey.speed = FleeingSpeed;//keeps the speed at fleeing


        if (!RandomBumperLocationChosen) //if the location for the monkey to move to have not been set then generate a random location
        {
            RandomBumperGenerator();//calling the fucntion to generate a new random location for the monkey
        }

        if (RandomBumperLocationChosen)
        {
            monkey.SetDestination(RandomBumpLocation);//sets the agent to move towards the random location if the random locationchosen bool is set to true
        }//if the raycast below doent detect ground on the map then itll look for another random location that is on  the ground before setting this bool to true and moving the monkey to the new location on the map.

        Vector3 distanctToRandomLocation = transform.position - RandomBumpLocation;//this new variable calculated the distance between the monkey and the random location generated

        if (distanctToRandomLocation.magnitude < 1f)//if the distance calculated is lessthan 1 that meand the monkey has reached that randomly generated location
        {
            RandomBumperLocationChosen = false;//as they have reached their destination the bool is set to false resetting and regenerating a new random location for the monkey to move towards
            Debug.Log("Has moved to bumper location!!!");

            BumperCollided = false;//setting this movement back to false
        }

       

    }



    private void Fleeing()//function for fleeing the player character
    {

        monkey.speed = FleeingSpeed;

        Vector3 RandomFleeing = transform.position - Player.transform.position;//creates a new vector 3 opposit of the player location
        RandomFleeing.Normalize();//this maintains  the same speed when running from the player

        monkey.SetDestination(transform.position + RandomFleeing * distanceFromPlayer);// setting a new target area for the monkey to run towards away from the player



    }//this sets the destination to - the players position in the map. but we will only trigger this is the player gets too close to the monkey







    void RandomLocationGenerator()//function for gatering the random destinations the monkey has to move to while wandering
    {
        float RanX = Random.Range(-RangeOfRandomLocation, RangeOfRandomLocation);//this calculated the random value for the x axis by using the float variable created previously
        float RanZ = Random.Range(-RangeOfRandomLocation, RangeOfRandomLocation);//this calculates the random value for the z axis by using the float variable created previously
      
        //Note not value for y as we dont want the monkey flying around all over the place
        RandomLocation = new Vector3(transform.position.x + RanX, transform.position.y,transform.position.z + RanZ);//this sets the new coordinated for the random location


        //raycasting used to make sure the new random location confines the monkey to the map by checking if its on the ground
        if(Physics.Raycast(RandomLocation, -transform.up, 4f, IsMap))
        {
            RandomLocationChosen = true;// we set this variable to true if the monkey is on the ground/ in the map boundaries
        }

    }



    void RandomBumperGenerator()//function for gatering the random destinations the monkey has to move to while wandering
    {
        float RanX = Random.Range(-RangeOfRandomBumperFleeing, RangeOfRandomBumperFleeing);//this calculated the random value for the x axis by using the float variable created previously
        float RanZ = Random.Range(-RangeOfRandomBumperFleeing, RangeOfRandomBumperFleeing);//this calculates the random value for the z axis by using the float variable created previously

        //Note not value for y as we dont want the monkey flying around all over the place
        RandomBumpLocation = new Vector3(transform.position.x + RanX, transform.position.y, transform.position.z + RanZ);//this sets the new coordinated for the random location


        //raycasting used to make sure the new random location confines the monkey to the map by checking if its on the ground
        if (Physics.Raycast(RandomBumpLocation, -transform.up, 4f, IsMap))
        {
            RandomBumperLocationChosen = true;// we set this variable to true if the monkey is on the ground/ in the map boundaries
        }

    }





    private void OnDrawGizmos()
    {
        //this will draw a yellow wire mesh arou dthe monkey to visualize the distancefromplayer variable. as this  is public we can adjust the distance in the inspector window
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, distanceFromPlayer);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, RangeOfRandomLocation);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, RangeOfRandomBumperFleeing);
    }

}

























    //old random movement code not including nav mesh
    /*

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
*/


