using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this.gameObject, 30);
        seed = Random.Range(1000, 2000);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "brick")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            Debug.Log("Explosion");

        }
    }

    float seed;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += transform.forward * speed * Time.deltaTime;

        float n1 = Mathf.PerlinNoise(Time.time + seed, 1);
        float n2 = Mathf.PerlinNoise(Time.time + (seed * 2.0f), 1);
        float n3 = Mathf.PerlinNoise(Time.time + (seed * 0.5f), 1);

        Vector3 noise = new Vector3(Utilities.Map(n1, 0, 1, -1, 1), Utilities.Map(n2, 0, 1, -1, 1), Utilities.Map(n3, 0, 1, 0, 1));
        noise = transform.TransformDirection(noise);

        pos += (noise * Time.deltaTime);
        transform.position = pos;
        //transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
