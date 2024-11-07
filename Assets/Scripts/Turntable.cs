using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{

    public float rotationSpeed = 1.0f;  // Speed of rotation around the pivot point
    public float maxAngle = 45.0f;      // Maximum angle for back-and-forth rotation
    public float pivotDistance = 5.0f;  // Distance of the pivot point from the camera along its initial forward direction

    private Vector3 pivotPoint;         // The point to rotate around
    private float currentAngle = 0.0f;  // Track the current rotation angle
    private int direction = 1;          // Rotation direction (1 for clockwise, -1 for counterclockwise)
    private float initalZAngle;         // Initial z angle of the camera

    void Start()
    {
        // Set the pivot point in the direction the camera is currently facing, at a fixed distance
        pivotPoint = transform.position + transform.forward * pivotDistance;
        initalZAngle = transform.eulerAngles.z;
    }

    void Update()
    {
        // Calculate the rotation angle for this frame
        float rotationStep = direction * rotationSpeed * Time.deltaTime;
        currentAngle += rotationStep;

        // Reverse direction if the max angle is reached
        if (Mathf.Abs(currentAngle) >= maxAngle)
        {
            direction *= -1;
        }

        // Calculate the new position by rotating around the pivot point
        Quaternion rotation = Quaternion.Euler(0, rotationStep, 0);
        Vector3 directionToPivot = transform.position - pivotPoint;
        Vector3 rotatedDirection = rotation * directionToPivot;

        // Update the camera's position and make it look at the pivot point
        transform.position = pivotPoint + rotatedDirection;
        transform.LookAt(pivotPoint);
        transform.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, initalZAngle);
    }
}
