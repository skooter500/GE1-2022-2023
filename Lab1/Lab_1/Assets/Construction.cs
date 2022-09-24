using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public GameObject cubepref;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cubepref, gameObject.transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
