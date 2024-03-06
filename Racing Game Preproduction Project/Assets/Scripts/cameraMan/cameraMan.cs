using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class cameraMan : MonoBehaviour
{
    public Camera cameraMansCam;
    //size of the image making it a square
    public int imageWidth = 720;
    public int imageHeight = 720;
    public float[] timeToTakePic = new float[3];//number of times i want to take a picture and at the different intervauls 
    private int currentImageTaken = 0;//number of times a picture was taken
    private RenderTexture[] imageRender;//the objects the images render onto
    private Texture2D[] imageTexture;//the images themselves
    public Image[] imageDisplays;//objects in the scene i can render the images onto

    private void Start()
    {
        
        imageRender = new RenderTexture[timeToTakePic.Length];
        imageTexture = new Texture2D[timeToTakePic.Length];//initializing the renderer and the textures
        
        //both are assigned the same width and height...
        for (int i = 0; i < timeToTakePic.Length; i++)
        {
            imageRender[i] = new RenderTexture(imageWidth, imageHeight, 24);
            cameraMansCam.targetTexture = imageRender[i];
            imageTexture[i] = new Texture2D(imageWidth, imageHeight, TextureFormat.RGB24, false);
        }

        StartCoroutine(SnapshotTiming());//starting coroutine
    }

    IEnumerator SnapshotTiming()//this takes a picture at each intervaul based on the game time and the preset times
    {
        while (currentImageTaken < timeToTakePic.Length)
        {
            float timeBeforeNextPicture = timeToTakePic[currentImageTaken] - Time.time;
            yield return new WaitForSeconds(Mathf.Max(timeBeforeNextPicture, 0f));
            TakeSnapShot(currentImageTaken);
            DisplayImage(currentImageTaken);
            Debug.Log("Image taken at time: " + Time.time);

            currentImageTaken++;
        }
    }

    private void TakeSnapShot(int index)//this function assigns the image we take to its allocated renderable object
    {
        RenderTexture.active = imageRender[index];
        imageTexture[index].ReadPixels(new Rect(0, 0, imageWidth, imageHeight), 0, 0);
        imageTexture[index].Apply();
        byte[] bytes = imageTexture[index].EncodeToPNG();//also turns the pixels captured from the camermancam into and actual PNG image
    }

    private void DisplayImage(int index)//physically displaying the images on the renderable objects i create in the scene on the canvas...
    {   Debug.Log("Image Properties - Index: " + index);
        Debug.Log("Width: " + imageTexture[index].width);
        Debug.Log("Height: " + imageTexture[index].height);
        Debug.Log("Format: " + imageTexture[index].format);
        Debug.Log("Displaying image at index: " + index);


        Sprite sprite = Sprite.Create(imageTexture[index], new Rect(0, 0, imageWidth, imageHeight), Vector2.zero);
        imageDisplays[index].sprite = sprite;
      
    }

}



//TODO: camera man is picky and only likes to take the third picture and display its instead of all three.. maybe he's hungry?