using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab; 

    public float fireRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Shoot()
    {
        GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = spawnPoint.position;
        bullet.transform.rotation = this.transform.rotation;
    }

    void OnEnable()
    {
        StartCoroutine(ShootingCoroutine());
    }

    bool shooting = false;

    System.Collections.IEnumerator ShootingCoroutine()
    {
        while(true)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                yield return new WaitForSeconds(1.0f / fireRate);
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
