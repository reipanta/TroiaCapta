using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioSaver : MonoBehaviour
{
    // Storing Rect and Camera variables here since we don't want to create new objects in Update() every frame
    private Camera camera;
    private Rect rect;

    // float values for 16:9 target aspect ratio 
    private const float TargetAspectWidth = 16.0f;
    private const float TargetAspectHeight = 9.0f;

    // aspect = width / height, both targetAspect and currentAspect will be calculated inside the function
    private float targetAspect;  
    private float currentAspect;

    // Vertical and horizontal scaling parameters are needed for resizing
    // and adjusting vertical and horizontal blackboxes  
    private float scaleHeight;
    private float scaleWidth;

    private void Start()
    {
        // Initializing camera in Start() because doing so in Update() is very memory expensive
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        // Calling this function every frame to adjust aspect ratio when resizing the window
        SetCameraAspect_16x9();
    }

    void SetCameraAspect_16x9()
    {
        // Calculating the aspect of 16:9 in one float number
        targetAspect = TargetAspectWidth / TargetAspectHeight;
        
        // Calculating the aspect of the current game window
        // by accessing two static properties, width and height, of the Screen class
        currentAspect = (float)Screen.width / (float)Screen.height;

        // scaleHeight variable shows how much current aspect differs from 16:9 aspect vertically and how it should be adjusted  
        scaleHeight = currentAspect / targetAspect;

        if (scaleHeight < 1.0f) // If true, then the screen is taller than the desired aspect ratio
        {
            rect = camera.rect; // Get current camera rectangle parameters

            rect.width = 1f; // Width goes from 0 to 1 and it's not affected by height so we default it to maximum
            rect.height = scaleHeight; // scaleHeight < 1, so we set height to this number 
            rect.x = 0f; // x coordinate (width) isn't affected and stays default 
            
            rect.y = (1f - scaleHeight) / 2f; // The difference between max. height (1f) and scaleHeight
                                              // is divided by 2 to create two equally shaped blackboxes
                                              // at the top and at the bottom of the screen

            camera.rect = rect; // Setting camera rectangle to the computated height & width values
        }
        else
        {
            rect = camera.rect;

            scaleWidth = 1f / scaleHeight; // Inverting the ratio since scaleHeight >= 1 for this case
            rect.width = scaleWidth; // Setting width to a current fraction of width
            rect.height = 1f; // Again, height goes from 0 to 1 and it's not affected by width so we default it to maximum
            rect.x = (1f - scaleWidth) / 2f; // Creating two similar blackboxes on the left and on the right
            rect.y = 0f; // y coordinate (height) isn't affected and stays default 

            camera.rect = rect; // Setting camera rectangle to the computated height & width values
        }
    }
}