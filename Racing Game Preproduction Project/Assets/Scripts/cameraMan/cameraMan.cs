

//this version works as in rendering each image correctly but doesnt let the player view the game from the car cameras

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraMan : MonoBehaviour
{
    public Camera cameraMansCam;
    public GameObject player;
    public Image[] imageDisplays;
    public float[] timeToTakePic = new float[3]; // Times to take pictures
    public float yOffsetToPlayer; // Offset from player position
    public bool pictureTaken = false;

    private int currentImageIndex = 0;
    private Texture2D imageTexture;

    private void Start()
    {
        StartCoroutine(SnapshotTiming());
    }

    IEnumerator SnapshotTiming()
    {
        while (currentImageIndex < timeToTakePic.Length)
        {
            // Activate cameraman's camera
            cameraMansCam.enabled = true;

            yield return new WaitForSeconds(timeToTakePic[currentImageIndex]);
            TakeSnapShot(currentImageIndex);
            DisplayImage(currentImageIndex);
            currentImageIndex++;
            pictureTaken = true;

            // Deactivate cameraman's camera
            cameraMansCam.enabled = false;
        }
    }

    void TakeSnapShot(int index)
    {
        // Calculate camera position
        Vector3 cameraPosition = player.transform.position + new Vector3(0, yOffsetToPlayer, 0);
        cameraMansCam.transform.position = cameraPosition;
        cameraMansCam.transform.LookAt(player.transform.position);

        // Take a picture
        RenderTexture rt = new RenderTexture(720, 720, 24);
        cameraMansCam.targetTexture = rt;
        imageTexture = new Texture2D(720, 720, TextureFormat.RGB24, false);
        cameraMansCam.Render();
        RenderTexture.active = rt;
        imageTexture.ReadPixels(new Rect(0, 0, 720, 720), 0, 0);
        imageTexture.Apply();
        byte[] bytes = imageTexture.EncodeToPNG(); // Save image data if needed
        cameraMansCam.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
    }
    void DisplayImage(int index)
    {
        Sprite sprite = Sprite.Create(imageTexture, new Rect(0, 0, 720, 720), Vector2.zero);
        imageDisplays[index].sprite = sprite;
    }
}

//Below version works with the camera/ its movement


//using System.Collections;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;
//public class cameraMan : MonoBehaviour
//{
//    public Camera cameraMansCam;
//    //size of the image making it a square
//    public int imageWidth = 720;
//    public int imageHeight = 720;
//    public float[] timeToTakePic = new float[3];//number of times i want to take a picture and at the different intervauls 
//    private int currentImageTaken = 0;//number of times a picture was taken
//    private RenderTexture[] imageRender;//the objects the images render onto
//    private Texture2D[] imageTexture;//the images themselves
//    public Image[] imageDisplays;//objects in the scene i can render the images onto

//    //to determine car the camera should follow...
//    public GameObject smallCar;
//    public GameObject mediumCar;
//    public GameObject largeCar;
//    public Transform playersPosition;
//    public float zOffsetToPlayer;
//    public float xOffsetToPlayer;
//    public float yOffsetToPlayer;
//    public bool pictureTaken = false;

//    private void Start()
//    {


//        //random offsets for the cameraman to take pictures of the player at different angles
//        pictureTaken = false;
//        zOffsetToPlayer = Random.Range(-10, 20);
//        xOffsetToPlayer = Random.Range(-10, -20);
//        yOffsetToPlayer = Random.Range(10, 20);

//        smallCar = GameObject.Find("Small Car");
//        mediumCar = GameObject.Find("Medium Car");
//        largeCar = GameObject.Find("Large Car");

//        if (smallCar != null)
//        {
//            playersPosition = smallCar.transform;
//        }

//        if (mediumCar != null)
//        {
//            playersPosition = mediumCar.transform;
//        }

//        if (largeCar != null)
//        {
//            playersPosition = largeCar.transform;
//        }

//        imageRender = new RenderTexture[timeToTakePic.Length];
//        imageTexture = new Texture2D[timeToTakePic.Length];//initializing the renderer and the textures

//        //both are assigned the same width and height...
//        for (int i = 0; i < timeToTakePic.Length; i++)
//        {
//            imageRender[i] = new RenderTexture(imageWidth, imageHeight, 24);
//            cameraMansCam.targetTexture = imageRender[i];
//            imageTexture[i] = new Texture2D(imageWidth, imageHeight, TextureFormat.RGB24, false);
//        }


//        StartCoroutine(SnapshotTiming());//starting coroutine
//    }

//    private void Update()//update for cameraman movement
//    {
//        this.gameObject.transform.position = new Vector3(playersPosition.position.x + xOffsetToPlayer, playersPosition.position.y + yOffsetToPlayer, playersPosition.position.z + zOffsetToPlayer);
//        this.gameObject.transform.LookAt(playersPosition.transform.position);//always faces the players position

//        if (pictureTaken)
//        {
//            MoveCameraMan();//if picture taken move the cameraman to new location
//        }

//    }


//    void MoveCameraMan()
//    {
//        Debug.Log("function called for movement");
//        //call this function to move the cameraman to a new offset to take a picture of the player from a different angle...
//        zOffsetToPlayer = Random.Range(-10, 20);
//        xOffsetToPlayer = Random.Range(-10, -20);
//        yOffsetToPlayer = Random.Range(10, 20);
//        pictureTaken = false;
//        Debug.Log("stop moving camera");
//    }





//IEnumerator SnapshotTiming()//this takes a picture at each intervaul based on the game time and the preset times
//{


//    while (currentImageTaken < timeToTakePic.Length)
//    {

//        float timeBeforeNextPicture = timeToTakePic[currentImageTaken] - Time.time;
//        yield return new WaitForSeconds(Mathf.Max(timeBeforeNextPicture, 0f));
//        TakeSnapShot(currentImageTaken);
//        DisplayImage(currentImageTaken);
//        Debug.Log("Image taken at time: " + Time.time);
//        currentImageTaken++;
//        pictureTaken = true;
//        Debug.Log("picture taken can move to new position");

//    }

//}

//private void TakeSnapShot(int index)//this function assigns the image we take to its allocated renderable object
//{
//    RenderTexture.active = imageRender[index];
//    imageTexture[index].ReadPixels(new Rect(0, 0, imageWidth, imageHeight), 0, 0);
//    imageTexture[index].Apply();
//    byte[] bytes = imageTexture[index].EncodeToPNG();//also turns the pixels captured from the camermancam into and actual PNG image

//    imageTexture[index].SetPixels(imageTexture[index].GetPixels());
//    imageTexture[index].Apply();


//}

//private void DisplayImage(int index)//physically displaying the images on the renderable objects i create in the scene on the canvas...
//{   
//    pictureTaken = true;
//    Debug.Log("picture teaken" + currentImageTaken);

//    Sprite sprite = Sprite.Create(imageTexture[index], new Rect(0, 0, imageWidth, imageHeight), Vector2.zero);
//    imageDisplays[index].sprite = sprite;

//}

//}

//CURRENTLY NOT RESETTING IMAGES FOR THE PICTURES AFTER THE GAME RESTARTS EITHER
//CURRENTLY NOT TAKING IMAGE 1 AND 2 ONLY 3
//just remove sprites from the images on reset

