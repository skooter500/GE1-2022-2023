using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    private TankControls tc;

    public GameObject bulletPrefab;
    public Transform spawnPoint;

    public float fireRate = 5;

    void Awake()
    {
        tc = new TankControls();
    }

    void OnEnable()
    {
        tc.Enable();
    }

    void OnDisable()
    {
        tc.Disable();
    }

    public float speed = 5;
    public float rotSpeed = 180;

    void Update()
    {
        float f = tc.Ground.Move.ReadValue<float>();
        transform.Translate(0, 0, speed * f * Time.deltaTime);

        /*
        Vector3 p = transform.position;
        p += transform.forward * speed * Time.deltaTime;

        transform.position = p;
        */

        float r = tc.Ground.Rotate.ReadValue<float>();

        transform.Rotate(0, rotSpeed * r * Time.deltaTime, 0);

        float b = tc.Ground.Shoot.ReadValue<float>();
        //GameManager.Log("Shooting: " + b);

    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = spawnPoint.position;
            yield return new WaitForSeconds(1 / (float)fireRate);
        }
    }


    Coroutine shootCR = null;
    public void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.phase == InputActionPhase.Started && shootCR == null)
        {
            shootCR = StartCoroutine(ShootCoroutine());
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            StopCoroutine(shootCR);
            shootCR = null;
        }


        //Debug.Log(context.performed);
    }

    void Start()
    {
        Vector3 a = new Vector3(5,6, 0);
        Vector3 b = new Vector3(11, 8, 0);

        Vector3 c = b - a;
        float theta = 90 + Mathf.Atan(c.y / c.x) * Mathf.Rad2Deg;

        Debug.Log(theta);


    }


    public void Move(InputAction.CallbackContext context)
    {
        float f = context.ReadValue<float>();
        Debug.Log(f);


    }

    /*
    private TankControls tc;
    // Start is called before the first frame update
    void Start()
    {
        // Add listenets to events
        tc.Land.Shoot.started += Shoot;
    }

    void Awake()
    {
        tc = new TankControls();
    }

    void Shoot(InputAction.CallbackContext context)
    {

    }

    void OnEnable()
    {
        tc.Enable();
    }

    void OnDisable()
    {
        tc.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float f = tc.Land.Move.ReadValue<float>();
        Debug.Log(f);
    }
    */
}
