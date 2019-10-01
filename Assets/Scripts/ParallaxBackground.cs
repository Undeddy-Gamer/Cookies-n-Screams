using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    //width in 'unity' points of size of image panel
    public float backgroundSize;
    // extra speed or lack of speed for the panel to move when the main camera moves
    public float paralaxSpeed;
    
    // The main camera that moves 'right' based on player interaction
    private Transform cameraTransform;

    // An array of the layers that will be moved to create continuious scroll and parallax
    private Transform[] layers;

    // Multiplier to help manage when the image is moved
    private float viewZone = 6;

    // The array index of the far left side image panel
    private int leftIndex;

    // The array index of the far right side image panel
    private int rightIndex;

    // The last x position of the Camera
    private float lastCameraX;


    private void Start()
    {
        //get the main camera
        cameraTransform = Camera.main.transform;

        // Get the initial x position of the camera
        lastCameraX = cameraTransform.position.x;

        // create a 'Tranform' array based on the amount of objects within our parallax parent object
        layers = new Transform[transform.childCount];

        // get the image layers from our parallax parent    
        for (int i = 0; i < transform.childCount; i++)
        {
            // for each object within the parallax parent object, add it to our layer array
            layers[i] = transform.GetChild(i);
        }

        // To begin with left index is 0 (first item of the array)
        leftIndex = 0;

        // Set right index to the amount of layers for the background (minus one due to index starting at 0)
        rightIndex = layers.Length - 1;

    }

    private void Update()
    {
       
        // Get the x movement speed of the camera
        float deltaX = cameraTransform.position.x - lastCameraX;

        // move the panel * the paralax speed variable
        transform.position += Vector3.right * (deltaX * paralaxSpeed);

        // set lastCamera x as current camera x
        lastCameraX = cameraTransform.position.x;

        //check to see if the camera is going 'right'
        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            goRight();
        }
    }

    
    // Function that moves the position of the farthest left background layer image to the be the farthest right image 
    // continuing the background seemlessly (as long as the background image sides match)
    private void goRight()
    {
        // left indexes for panels within the layers array to move and set
        int lastLeft = leftIndex;

        // move the left image panel to the right side of the 'last' right image panel
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);

        // set the right image panel to that newly moved image panel
        rightIndex = leftIndex;

        // LeftIndex is now the next image panel in the list
        leftIndex++;

        // fix if left index goes out of bounds due to ++
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }

}
