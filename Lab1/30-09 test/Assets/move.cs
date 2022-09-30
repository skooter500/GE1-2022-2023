using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float f = Input.GetAxis("Vertical");
        Debug.Log("f: " + f);
        gameObject.transform.Translate(0, 0, f * speed * Time.deltaTime);
    }
}
