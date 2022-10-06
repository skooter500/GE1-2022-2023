using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodecahedron : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] int loops = 5;
    float circumference;
    float radius;
    int s = 0;
    // Start is called before the first frame update
    void Start()
    {
        while(radius >= 0) {
            loops--;
            radius = loops/2;
            circumference = 2 * Mathf.PI * radius;
            s = (int) (circumference / (2*0.5));
        }

        transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(1f, 1f, 1f);

        radius--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
