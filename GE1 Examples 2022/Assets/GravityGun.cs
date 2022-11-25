using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public float holdDistance = 1;
    public float maximumVelocity = 30;
    public float powerFactor = 40;

    GameObject pickedUp = null;
    Transform camera;

    public bool isPhisGun = false;

    public Texture2D crosshairImage;

    void OnGUI()
    {

        float w = 50;
        float xMin = (Screen.width / 2) - (w / 2);
        float yMin = (Screen.height / 2) - (w / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, w, w), crosshairImage);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        if (camera == null)
        {
            camera = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (pickedUp == null)
            {
                RaycastHit rch;

                if (Physics.Raycast(camera.position, camera.forward, out rch))
                {
                    if (rch.collider.gameObject.tag != "groundPlane")
                    {
                        pickedUp = rch.collider.gameObject;
                        if (isPhisGun)
                        {
                            holdDistance = Vector3.Distance(camera.position, pickedUp.transform.position);
                        }
                    }

                }
            }
            else
            {
                Vector3 holdPos = camera.position + camera.forward * holdDistance;
                Vector3 toHoldPos = holdPos - pickedUp.transform.position;
                toHoldPos *= powerFactor;
                toHoldPos = Vector3.ClampMagnitude(toHoldPos, maximumVelocity);
                pickedUp.transform.GetComponent<Rigidbody>().velocity = toHoldPos;
            }
        }
        else
        {
            pickedUp = null;
        }
    }
}
