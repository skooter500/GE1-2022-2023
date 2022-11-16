using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSript : MonoBehaviour
{
    [SerializeField] private string up, down, left, right;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject PlayerShown;
    private Rigidbody rb;

    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
        move();

    }

    private void move()
    {
        if (Input.GetKey(up))
        {

            rb.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);

        }
        if (Input.GetKey(left))
        {
            Debug.Log("left");

            rb.AddForce(-Vector3.right * speed, ForceMode.VelocityChange);

        }
        if (Input.GetKey(right))
        {
            Debug.Log("Right");

            rb.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
        }
        if (Input.GetKey(down))
        {

            Debug.Log("down");

            rb.AddForce(-Vector3.forward * speed, ForceMode.VelocityChange);
        }


        if (rb.velocity != Vector3.zero)
        {
            rb.drag = 3;
            PlayerShown.transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        }
        else
        {
            rb.drag = 20;
        }


    }


    private void shoot()
    {
        var bul = Instantiate(bullet, PlayerShown.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        bul.transform.forward = PlayerShown.transform.forward;
        bul.GetComponent<Rigidbody>().AddForce(bul.transform.forward * 20, ForceMode.VelocityChange);
        Destroy(bul, 10f);

    }

}
