using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePhysicsCube : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 gravity  = new Vector3(0,-9.8f, 0); 
    void Start()
    {
        float t = Mathf.Sqrt((transform.position.y) / (0.5f * -gravity.y));
        float s =  -gravity.y * t;
        Debug.Log("Time: " + t);
        Debug.Log("Speed: " + s);
        
    }

    public float time;
    public Vector3 v = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 0)
        {
            // Integration!
            v += gravity * Time.deltaTime;
            transform.position += v * Time.deltaTime;
            time += Time.deltaTime;
        }
        else
        {
            Debug.Log("Final time: " + time);
            Debug.Log("Velocity: " + v);
        }
    }
}
