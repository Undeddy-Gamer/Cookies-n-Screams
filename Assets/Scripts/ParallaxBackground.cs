using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float backgroundSize;
    public float paralaxSpeed;
    public int layerNo = 5;
    public Canvas canvas;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 6;

    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];

        for( int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        //set right index to the amount of layers for the background (minus one due to index starting at 0)
        rightIndex = layers.Length - 1;
        
    }

    private void Update()
    {
        /*
            if (Input.GetKeyDown(KeyCode.A))
                ScrollLeft();
            else if (Input.GetKeyDown(KeyCode.D))
                ScrollRight();
        */
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * paralaxSpeed);
        
        lastCameraX = cameraTransform.position.x;

       

        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
        {
            goLeft();
        }

        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            goRight();
        }

        //transform.position = new Vector3(transform.position.x, transform.position.y, layerNo);
    }


    private void goLeft()
    {

        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void goRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }

}
