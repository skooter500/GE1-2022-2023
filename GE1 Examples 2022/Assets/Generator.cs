using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    public float MaxRadius;

    // Start is called before the first frame update
    void Start()
    {


        for(float Radius = 2; Radius < MaxRadius; Radius++)
        {
            for (float i = 0; i < 360; i += 30 /(Radius/2))
            {
                float angle = i  * Mathf.Deg2Rad;
                Vector2 SpawnPos;
                SpawnPos.x = (Radius * Mathf.Cos(angle)) +transform.position.x;
                SpawnPos.y = (Radius * Mathf.Sin(angle)) +transform.position.y;
                var Gobj = Instantiate(prefab, SpawnPos, transform.rotation);
                Gobj.transform.parent = transform;
            }
        }
       
    }

    private void Update()
    {
        transform.Rotate(0,0,0.1f);
    }


}
