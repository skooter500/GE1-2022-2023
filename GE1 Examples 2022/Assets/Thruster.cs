using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Thruster : MonoBehaviour
{
    public InputActionProperty input;
    public Transform thruster;
    public float speed = 1.0f;

    private Vector3 maxScale;
    // Use this for initialization
    void Start()
    {
        maxScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float fire = input.action.ReadValue<float>();
        Vector3 newScale = Vector3.Lerp(transform.localScale, maxScale * fire, Time.deltaTime * speed * 2);
        transform.localScale = newScale;

    }
}
