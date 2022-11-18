using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin2 : MonoBehaviour
{
    public float speed;
    public float timeAcc;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.5f)
        {
            rb.isKinematic = true;
        }
        else
        {
            timeAcc += Time.deltaTime;
            speed = rb.velocity.magnitude;
        }
    }
}
