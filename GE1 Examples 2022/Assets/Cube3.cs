using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube3 : MonoBehaviour
{
    public float amplitude = 1.0f; // The amplitude of the motion
    public float frequency = 1.0f; // The frequency of the motion

    void Update()
    {
        // Calculate the new position
        float x = amplitude * Mathf.Sin(frequency * Time.time);
        float y = amplitude * Mathf.Cos(frequency * Time.time);

        // Update the position of the cube
        transform.position = new Vector3(x, y, 0);
    }
}