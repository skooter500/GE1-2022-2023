using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    System.Collections.IEnumerator Spawn()
    {
        while(true)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
            g.AddComponent<Rigidbody>();
            g.transform.position = transform.position;
            yield return new WaitForSeconds(.2f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
