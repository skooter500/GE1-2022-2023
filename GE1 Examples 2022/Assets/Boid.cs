using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;

    public Vector3 Seek()
    {
        Vector3 desired = target.position - transform.position;
        desired.Normalize();
        desired *= 5.0f;
        return desired - velocity;
   }

    // Update is called once per frame
    void Update()
    {

        force = Seek();
        acceleration = force;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (velocity.magnitude > 0)
        {
            transform.forward = velocity;
        }
    }
}
