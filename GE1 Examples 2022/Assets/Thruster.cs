using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Thruster : MonoBehaviour
{
    public InputActionProperty input;
    public Rigidbody player;
    public float newtons = 1000.0f;
    private AudioSource audioSource;

    private float maxScale;
    // Use this for initialization
    void Start()
    {
        maxScale = transform.localScale.z;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        float fire = input.action.ReadValue<float>();
        float newScale = Mathf.Lerp(transform.localScale.z, maxScale * fire, Time.deltaTime);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newScale);

        Vector3 f = transform.forward * fire * newtons * Time.deltaTime;
        player.AddForce(-f);
        audioSource.volume = newScale;
        audioSource.pitch = newScale * 2.0f;
    }
}
