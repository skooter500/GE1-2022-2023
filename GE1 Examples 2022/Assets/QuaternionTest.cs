using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{

    public Transform cube1;
    public Transform cube2;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q;

        Vector3 toTarget = cube1.position - transform.position;
        toTarget.Normalize();
        float dot = Vector3.Dot(toTarget, transform.forward);
        float theta = Mathf.Acos(dot);

        q = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.up);

        transform.rotation = q;

    }
}
