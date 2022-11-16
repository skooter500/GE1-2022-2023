using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform bulletspawn;
    private GameObject Player;
    private bool turn = false;
    [SerializeField] private GameObject Bullet;
   [SerializeField] private float firecooldown = -10;
  [SerializeField]  private float maxfirecooldown = 5;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Shood());
    }

    // Update is called once per frame
    void Update()
    {

       if(firecooldown > 0)
       {
            firecooldown -= 1 * Time.deltaTime;
       }
        if(turn == true)
        {
            if (maxfirecooldown > 0.05f)
            {
                maxfirecooldown -= 0.2f * Time.deltaTime;
            }
            transform.LookAt(Player.transform.position);
        }
    }

    private IEnumerator Shood()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 50)
        {
            if (firecooldown < 0)
            {
                GameObject bul = Instantiate(Bullet, bulletspawn.position, Quaternion.identity);
                bul.transform.LookAt(Player.transform.position);
                bul.GetComponent<Rigidbody>().AddForce((bul.transform.forward * 10)/(maxfirecooldown), ForceMode.VelocityChange);
                firecooldown = maxfirecooldown;
                Destroy(bul, 5f);
            
            }
        }
        yield return new WaitForSeconds(firecooldown);
        StartCoroutine(Shood());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            turn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            turn = false;
            maxfirecooldown = 5;
        }
    }
}
