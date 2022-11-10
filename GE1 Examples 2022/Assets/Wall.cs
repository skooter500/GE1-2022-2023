using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int width = 5, height = 10;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0 ; j < height ; j ++)
        {
            for(int i = 0 ; i < width ; i ++)
            {
                GameObject cube = GameObject.Instantiate(prefab);
                cube.tag = "brick";
                cube.transform.position = transform.TransformPoint(new Vector3(i, j, 0));
                cube.transform.rotation = transform.rotation;                
                cube.GetComponent<Renderer>().material.color =
                    Color.HSVToRGB( i * j / (float) (width * height), 1.0f, 1.0f); 
                Rigidbody rb = cube.GetComponent<Rigidbody>();
                rb.useGravity = false;
                cube.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
