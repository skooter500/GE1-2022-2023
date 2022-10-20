using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControler : MonoBehaviour
{
    public float speed = 5;
    public float rotSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0);
    }
}
