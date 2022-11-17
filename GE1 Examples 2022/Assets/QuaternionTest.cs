using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{

    public Transform cube1;
    public Transform cube2;
    private Quaternion start;
    private Quaternion end;
    private float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion q;

        Vector3 toTarget = cube1.position - transform.position;
        toTarget.Normalize();
        float dot = Vector3.Dot(toTarget, transform.forward);
        float theta = Mathf.Acos(dot);

        q = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.up);

        //transform.rotation = q;

        start = q;

        end = Quaternion.LookRotation(cube2.position - transform.position);

        t = 0;

        transform.rotation = start;

    }

    // Update is called once per frame
    void Update()
    {

        end = Quaternion.LookRotation(cube2.position - transform.position);

        Quaternion q = Quaternion.Slerp(start, end, t);
        transform.rotation = Quaternion.Slerp(transform.rotation, end, Time.deltaTime);

        //t += Time.deltaTime;
        //if (t < 1.0f )
        //{
        //    transform.rotation = q;
        //}
        ////Quaternion q;

        //Vector3 toTarget = cube1.position - transform.position;
        ////toTarget.Normalize();
        ////float dot = Vector3.Dot(toTarget, Vector3.forward);
        ////float theta = Mathf.Acos(dot);

        ////q = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.up);


        //Quaternion q = Quaternion.LookRotation(toTarget);

        //transform.rotation = q;

        //Vector3 a = new Vector3(0, 0, 10);

        //Quaternion q1 = Quaternion.AngleAxis(90, Vector3.up);
        //Quaternion q2 = Quaternion.AngleAxis(90, Vector3.right);

        //Quaternion q3 = q1 * q2;

        //a = q1 * a;

        //Debug.Log(a);

    }
}
