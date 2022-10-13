using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Transform head;
    public Transform tail;
    [Range(0.0f, 5.0f)]
    public float frequency = 0.5f;
    public float headAmplitude = 40;
    public float tailAmplitude = 60;

    public float theta = 0;

    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Your code goes here!

    }
}
