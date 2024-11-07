using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    private Camera cam;
    public List<Color> colors = new List<Color> {new Color(0.1921569f, 0.3019608f, 0.4745098f), new Color(1.0f, 0.5f, 0.0f), new Color(0.454902f, 0.4039216f, 0.7137255f) }; // Include orange or other custom colors here
    private int currentColorIndex = 0;

    void Start()
    {
        // Get the Camera component attached to this GameObject
        cam = GetComponent<Camera>();

        if (cam == null)
        {
            Debug.LogError("No Camera component found. Attach this script to a Camera object.");
            enabled = false;
            return;
        }

    }

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Change to the next color in the list
            ChangeBackgroundColor();
        }
    }

    void ChangeBackgroundColor()
    {
        // Move to the next color in the list, looping back to the start if necessary
        currentColorIndex = (currentColorIndex + 1) % colors.Count;
        cam.backgroundColor = colors[currentColorIndex];
    }
}
