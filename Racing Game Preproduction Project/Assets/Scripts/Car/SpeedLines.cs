using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLines : MonoBehaviour
{
    public Image speedLineAnimation;
    public DriftController carDriftControllerScript;
    private float alphaValue;
    [SerializeField] Animator speedlineAnimation;
    public float animSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        carDriftControllerScript = GetComponent<DriftController>();
        alphaValue = 0.0f; // default alpha value
        speedLineAnimation.enabled = true;
      

        // Set the image color to white and transparent
        speedLineAnimation.color = new Color(1f, 1f, 1f, alphaValue);
    }

    // Update is called once per frame
    void Update()
    {
        alphaValue = carDriftControllerScript.CurrentSpeed / carDriftControllerScript.TopSpeed;
        alphaValue = Mathf.Clamp01(alphaValue);
        
        speedLineAnimation.color = new Color(1f, 1f, 1f, alphaValue);

        speedlineAnimation.SetFloat("animationSpeed", alphaValue);
    }
}
