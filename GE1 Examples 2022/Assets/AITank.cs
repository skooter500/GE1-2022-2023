using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : MonoBehaviour
{
    public List<Vector3> waypoints;
    public int count = 5;
    public float radius = 5;

    public float speed;
    public float fov;

<<<<<<< HEAD
<<<<<<< HEAD
    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;    
=======
>>>>>>> b0e22f5cdd1412d252e7131cf7fb983d71476e71
=======
    public Transform player;
>>>>>>> 1e0441e142282104b27730ecbc36bbf753ec774b

    void SetUpWaypoints()
    {
        waypoints = new List<Vector3>();
        waypoints.Clear();
        float theta = (Mathf.PI * 2.0f) / (float) count;

        for(int i = 0 ; i < count ; i ++)
        {
<<<<<<< HEAD
            float theta = (Mathf.PI * 2.0f) / numWaypoints;
            for(int i = 0 ; i < numWaypoints ; i ++)
            {
                float angle = theta * i;
                Vector3 pos = new Vector3(Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle) * radius);
                pos = transform.TransformPoint(pos);
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(pos, 1); 
            }
=======
            float angle = i * theta;
            Vector3 p = new Vector3
                (
                    Mathf.Sin(angle) * radius, 
                    0,
                    Mathf.Cos(angle) * radius
                );
            p = transform.TransformPoint(p);
            waypoints.Add(p);
>>>>>>> b0e22f5cdd1412d252e7131cf7fb983d71476e71

        }
    }

<<<<<<< HEAD
    // Use this for initialization
    void Awake () {
        float theta = (Mathf.PI * 2.0f) / numWaypoints;
        for(int i = 0 ; i < numWaypoints ; i ++)
        {
            float angle = theta * i;
            Vector3 pos = new Vector3(Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos); 
=======
    void OnDrawGizmos()
    {
        SetUpWaypoints();
        foreach(Vector3 v in waypoints)
        {
            Gizmos.DrawWireSphere(v, 0.5f);
>>>>>>> b0e22f5cdd1412d252e7131cf7fb983d71476e71
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpWaypoints();

    }

    int current = 0;

    // Update is called once per frame
<<<<<<< HEAD
    void Update () {
        Vector3 pos = transform.position;
        Vector3 toNext = waypoints[current] - pos;
        float dist = toNext.magnitude;
        if (dist < 1)
        {
            current = (current + 1) % waypoints.Count;
        }
        Vector3 direction = toNext / dist;
        //pos += direction * speed * Time.deltaTime;
        //transform.position = pos;
        //
        //transform.forward = toNext;
        //transform.Translate(0, 0, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, waypoints[current], Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toNext, Vector3.up), 180 * Time.deltaTime);


        Vector3 toPlayer = player.position - transform.position;
        float dot = Vector3.Dot(transform.forward, toPlayer.normalized);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        if (angle < 45)
        {
            Debug.Log("Ïnside field of view");
        }

        if (dot > 0)
        {
            Debug.Log("iN FRONT");        
        }
        else
        {
            Debug.Log("behind");
        }

        float angle1 = Vector3.Angle(toPlayer, transform.forward);
=======
    void Update()
    {
        Vector3 totarget = waypoints[current] - transform.position;
        float dist = totarget.magnitude;
        if (dist < 1.0f)
        {
            current = (current + 1) % waypoints.Count;
        }
<<<<<<< HEAD
        transform.LookAt(waypoints[current]);
        transform.Translate(0, 0, speed * Time.deltaTime);
>>>>>>> b0e22f5cdd1412d252e7131cf7fb983d71476e71
=======
        Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(totarget), Time.deltaTime);
        //transform.rotation = q;
        //transform.Translate(0, 0, speed * Time.deltaTime);

        Vector3 toPlayer = player.position - transform.position;
        toPlayer.Normalize();
        float dot = Vector3.Dot(toPlayer, transform.forward);
       
        Debug.Log((dot > 0) ? "In front" : "behind");            
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        Debug.Log(angle);
        if (angle < 45)
        {
            Debug.Log("I casn see you");
        }
        else
        {
            Debug.Log("I cant see you");
        }

        float a = Vector3.AngleBetween(transform.forward, totarget);



>>>>>>> 1e0441e142282104b27730ecbc36bbf753ec774b
    }
}
