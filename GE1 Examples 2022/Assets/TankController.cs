using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed = 5;
    public float rotSpeed = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float c = Input.GetAxis("Vertical");
        transform.Translate(0, 0, c * speed * Time.deltaTime);

        float r = Input.GetAxis("Horizontal");
        transform.Rotate(0, r * rotSpeed * Time.deltaTime, 0);
    }
}
