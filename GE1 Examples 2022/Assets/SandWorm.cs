using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandWorm : MonoBehaviour {
    public int bodySegments = 10;
    public float radius = 50;
    public bool gravity = true;

    public float spring = 100;
    public float damper = 50;

    // Use this for initialization
	void Awake () {
        if (transform.childCount == 0)
        {
            Create();
        }
        Invoke("StartMoving", 5);
    }

    void StartMoving()
    {
        moving = true;
    }

    void Create()
    { 
        float depth = radius * 0.1f;
        Vector3 start = - Vector3.forward * bodySegments * depth * 2;
        GameObject previous = null;
        for (int i = 0; i < bodySegments; i++)
        {
            float r = radius;
            float d = damper;

            float mass = 1.0f;
            if (i < headtail)
            {
                r = radius * Mathf.Pow(0.6f, (headtail - i));
                mass = Mathf.Pow(0.6f, (headtail - i));
            }
            if (i > bodySegments - headtail - 1)
            {
                r = radius * Mathf.Pow(0.8f, i - (bodySegments - headtail - 1));
                mass = Mathf.Pow(0.8f, i - (bodySegments - headtail - 1));
            }
            GameObject bodyPart = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Rigidbody rb = bodyPart.AddComponent<Rigidbody>();
            rb.useGravity = gravity;
            rb.mass = mass;
            Vector3 pos = start + (Vector3.forward * depth * 4 * i);
            bodyPart.transform.position = transform.TransformPoint(pos);
            bodyPart.transform.rotation = transform.rotation;
            bodyPart.transform.parent = this.transform;           
            bodyPart.transform.localScale = new Vector3(r * 2, r * 2, depth);
            bodyPart.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            bodyPart.GetComponent<Renderer>().receiveShadows = false;

            bodyPart.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)bodySegments, 1, 1);

            if (previous != null)
            {
                HingeJoint j = bodyPart.AddComponent<HingeJoint>();
                j.connectedBody = previous.GetComponent<Rigidbody>();
                j.autoConfigureConnectedAnchor = false;
                j.axis = Vector3.right;
                j.anchor = new Vector3(0, 0, - 2f);
                j.connectedAnchor = new Vector3(0, 0, 2f);
                j.useSpring = true;
                JointSpring js = j.spring;
                js.spring = spring;
                js.damper = d;
                j.spring = js;
            }            
            previous = bodyPart;
        }
    }

    public float force = 100;
    
   
    private float offset = 0;
    public float speed = 1f;
    public int headtail = 2;
    public float current = 0;
    //int start = 2;
    public bool moving = false;

    public void Update()
    {
        if (moving)
        {
            Animate();
        }
    }

    public void Animate()
    {
        float f = force;
        Rigidbody rb = transform.GetChild((int) current).GetComponent<Rigidbody>();
        
        rb.AddTorque(- rb.transform.right * f);
        current += speed * Time.deltaTime;


        if (current >= transform.childCount)
        {
            current = 0;
        }
    }
}
