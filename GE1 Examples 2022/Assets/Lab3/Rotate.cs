using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject top,bottom;
    [SerializeField] private float Frequency , topamp, botamp, theta;
  

    void Update()
    {

        Frequency += theta *Time.deltaTime;
        float toprot =  Mathf.Sin(Frequency ) * topamp;
        float botrot = Mathf.Sin(Frequency) * botamp;

        top.transform.rotation = Quaternion.AngleAxis(toprot, new Vector3(0, 200, 0));
        bottom.transform.rotation = Quaternion.AngleAxis(botrot, new Vector3(50, 0,500));



    }
}
