using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioSaver : MonoBehaviour
{
    // Storing Rect and Camera variables here since we don't want to create new objects in Update() every frame
    private Camera _camera;
    private Rect _rect;
    private Vector3 _mousePosition; // TODO: Make mouse cursor disappear when colliding with vertical or horizontal blackboxes

    // float values for 16:9 target aspect ratio 
    private const float TargetAspectWidth = 16.0f;
    private const float TargetAspectHeight = 9.0f;

    // aspect = width / height, both targetAspect and currentAspect will be calculated inside the function
    private float _targetAspect;
    private float _currentAspect;

    // Vertical and horizontal scaling parameters are needed for resizing
    // and adjusting vertical and horizontal blackboxes  
    private float _scaleHeight;
    private float _scaleWidth;

    private void Start()
    {
        // Initializing camera in Start() because doing so in Update() is very memory expensive
        _camera = GetComponent<Camera>();
        _mousePosition = Input.mousePosition;
    }

    private void Update()
    {
        // Calling this function every frame to adjust aspect ratio when resizing the window
        SetCameraAspect_16x9();
    }

    void SetCameraAspect_16x9()
    {
        // Calculating the aspect of 16:9 in one float number
        _targetAspect = TargetAspectWidth / TargetAspectHeight;

        // Calculating the aspect of the current game window
        // by accessing two static properties, width and height, of the Screen class
        _currentAspect = (float)Screen.width / (float)Screen.height;

        // scaleHeight variable shows how much current aspect differs from 16:9 aspect vertically and how it should be adjusted  
        _scaleHeight = _currentAspect / _targetAspect;

        GenerateHorizontalBoxes();
        GenerateVerticalBoxes();
    }

    private void GenerateHorizontalBoxes()
    {
        if (_scaleHeight < 1.0f) // If true, then the screen is taller than the desired aspect ratio
        {
            _rect = _camera.rect; // Get current camera rectangle parameters

            _rect.width = 1f; // Width goes from 0 to 1 and it's not affected by height so we default it to maximum
            _rect.height = _scaleHeight; // scaleHeight < 1, so we set height to this number 
            _rect.x = 0f; // x coordinate (width) isn't affected and stays default 

            _rect.y = (1f - _scaleHeight) / 2f; // The difference between max. height (1f) and scaleHeight
            // is divided by 2 to create two equally shaped blackboxes
            // at the top and at the bottom of the screen

            _camera.rect = _rect; // Setting camera rectangle to the computated height & width values
        }
    }

    private void GenerateVerticalBoxes()
    {
        if (_scaleHeight >= 1.0f)
        {
            _rect = _camera.rect;

            _scaleWidth = 1f / _scaleHeight; // Inverting the ratio since scaleHeight >= 1 for this case
            _rect.width = _scaleWidth; // Setting width to a current fraction of width
            _rect.height =
                1f; // Again, height goes from 0 to 1 and it's not affected by width so we default it to maximum
            _rect.x = (1f - _scaleWidth) / 2f; // Creating two similar blackboxes on the left and on the right
            _rect.y = 0f; // y coordinate (height) isn't affected and stays default 

            _camera.rect = _rect; // Setting camera rectangle to the computated height & width values
        }
    }
}