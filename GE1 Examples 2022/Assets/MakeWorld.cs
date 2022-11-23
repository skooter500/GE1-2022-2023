using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float width = transform.localScale.x;
        float depth = transform.localScale.y;
        for(int i = 0 ; i < width ; i +=20)
        {
            for(int j = 0 ; j < depth ; j +=20)
            {
                float lower = - transform.localScale.x / 2;
                Vector3 pos = new Vector3(lower + i, 0, lower + j);
                float scale = Random.Range(2, 50);
                pos.y = scale / 2.0f;
                GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
                building.transform.localScale = new Vector3(5, scale, 5);                
                building.transform.position = pos;
                building.transform.parent = this.transform;      
                building.GetComponent<Renderer>().material.color = 
                    Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);          
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
