using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodecahedron : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] int loops = 8;
    int n = 0;
    float circumference;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        while(radius >= 0) {
            loops--;
            radius = loops/2;
            circumference = 2 * Mathf.PI * radius;
            n = (int) (circumference / (2*0.5));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
