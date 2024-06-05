using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    // Speed of the movement
    public float speed = 10.0f;

    // Distance the object will move
    public float distance = 40.0f;

    // Axis of movement
    public Vector3 movementAxis = Vector3.up;

    // Starting position of the object
    private Vector3 startPos;

    void Start()
    {
        // Record the starting position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new position using Mathf.PingPong
        float newPosition = Mathf.PingPong(Time.time * speed, distance);

        // Update the position of the object
        transform.position = startPos + movementAxis.normalized * newPosition;
    }
}