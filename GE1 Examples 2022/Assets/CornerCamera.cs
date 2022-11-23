using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class CornerCamera : MonoBehaviour
{
    public Transform cam;
    public Vector3 target;

    public Quaternion from;
    public float fromDistance;
    public float toDistance;
    public Quaternion to;

    public float angle = 45.0f;

    public float transitionTime = 2.0f;

    public float elapsed; 

    public float step = 25;
    public float min = 0;
    public float max = 200;
    public enum Transition {rotation, movement, time, shaderTime};

    public Transition transition = Transition.rotation; 

    Queue<Transition> transitions = new Queue<Transition>();

    //NematodeSchool ns;

    public Utilities.EASE ease;

    public float probeLength = 2;

    float lastf = 0.5f;

    float oldTime = 2.5f;
    float newTime = 0;
    float oldShaderTime = 0; 
    float newShaderTime = 0; 

    float oldTransitionTime = 0;

    bool stopped = true;

    public Light directionalLight;

    public Material material;

    public float fogMax = 500;

    


    public void StopStart(InputAction.CallbackContext context)
    {

        if (elapsed != transitionTime)
        {
            return;
        }
        if (context.phase != InputActionPhase.Performed)
        {
            return;
        }
        
        if (stopped)
        {
            Debug.Log("Starting");
            newTime = timeScale;
            oldTime = 0;            
            newShaderTime = oldShaderTime;            
            oldShaderTime = 0;
            elapsed = 0.0f;
            transition = Transition.time;
            
            //Invoke("ShaderTimeTransition", transitionTime);
        }
        else
        {
            Debug.Log("Stopping");            
            newTime = 0;
            oldTime = timeScale;            
            newShaderTime = 0;
            oldShaderTime = material.GetFloat("_TimeMultiplier");       
            //material.SetFloat("_TimeMultiplier", 0);
            elapsed = 0.0f;
            transition = Transition.time;
            oldTransitionTime = transitionTime;

            //Invoke("ShaderTimeTransition", transitionTime);
        }
    }

    public void Quit(InputAction.CallbackContext context)
    {
        shouldIgnore = true;
        Application.Quit();
    } 
    public void Light(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>() * 200;    
        Debug.Log("Center Light: " + f);    
        material.SetFloat("_CI", f);
    }

    public void Smoothness(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>();    
        Debug.Log("Smoothness: " + f);    
        material.SetFloat("_Glossiness", f);
    }
    
    public void Temp(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = (context.ReadValue<float>() - 0.5f) * 200;    
        Debug.Log("Temp: " + f);    
        //colorGrading.temperature.Override(f);
    }
    
    public void Tint(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = (context.ReadValue<float>() - 0.5f) * 200;    
        Debug.Log("Tint: " + f);    
       // colorGrading.tint.Override(f);    
    }

    public void Metalic(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>();    
        Debug.Log("Metalic: " + f);    
        material.SetFloat("_Metallic", f);
    }

    /*public void FogStart(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>() * 200;    
        Debug.Log("Fog STart: " + f);    
        RenderSettings.fogStartDistance = f;
        //material.SetFloat("_CI", f);
    }
    */

    public void FogEnd(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>() * fogMax;    
        Debug.Log("Fog End: " + f);    
        RenderSettings.fogEndDistance = f;
        //material.SetFloat("_CI", f);
    }



    void OnApplicationFocus(bool f)
    {
        //shouldIgnore = ! f;
    }

    public static bool shouldIgnore = false;
    private bool ShouldIgnore(InputAction.CallbackContext context)
    {
        //bool b = Mathf.Abs(Time.time - (float) context.time) > 600;
        if (shouldIgnore)
        {
            Debug.Log("Ignoring: " + context);
        }
        return shouldIgnore;
    }

    public void DisplayValues(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
        {
            return;
        }
        Debug.Log("Radius: " + radius);
        Debug.Log("Probe Length: " + probeLength);

        Debug.Log("Center Light: " + material.GetFloat("_CI"));
        Debug.Log("Directional Light: " + directionalLight.intensity);

        Debug.Log("Alpha: " + desiredAlpha);
        Debug.Log("Bloom: " + desiredBloom);

        Debug.Log("Fog: " + RenderSettings.fogEndDistance);
        Debug.Log("Smoothness: " + material.GetFloat("_Glossiness"));
        
        Debug.Log("Metalic: " + material.GetFloat("_Metallic"));
        Debug.Log("TimeScale: " + timeScale);
        

        Debug.Log("Range: " + desiredRange);
        Debug.Log("Color width: " + material.GetFloat("_ColorWidth"));
        
        
        //Debug.Log("Shift: " + colorGrading.hueShift.value);
        //Debug.Log("Temperature: " + colorGrading.temperature.value);

        //Debug.Log("Tint: " + colorGrading.tint.value);
        //Debug.Log("Shader Time: " + desiredShaderTime);
        
        Debug.Log("Camera Position: " + cam.transform.position);
        Debug.Log("Camera Rotation: " + cam.transform.rotation);
        
    }


    float desiredAlpha = 0.5f;
    public void Alpha(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>();    
        desiredAlpha = f;
        Debug.Log("Desired Alpha: " + desiredAlpha);    
        
    }
    public void AmbientLight(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        
        float f = context.ReadValue<float>() * 50;        
        Debug.Log("Directional Light: " + f);
        directionalLight.intensity = f;
    }

    private static float distance = -150;

    public void RestartScene(InputAction.CallbackContext context)
    {
        CornerCamera.distance = cam.transform.localPosition.z;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FeelerLength(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        
        float f = context.ReadValue<float>() * 4;        
        Debug.Log("Probe Length: " + f);
        probeLength = f;
    }

    //private Bloom bloom;
    //private ColorGrading colorGrading;
    //public PostProcessVolume volume;

    void OnApplicationQuit()
    {
        shouldIgnore = true;
    }

    float desiredBloom = 0;

    public void Bloom(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>() * 20;        
        Debug.Log("Bloom: " + f); 
        desiredBloom = f;        
    }

    public void ColorWidth(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>();        
        Debug.Log("Color Width : " + f);
        material.SetFloat("_ColorWidth", f);
        
    }


    public void ColorStart(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>();        
;
        Debug.Log("Color Start : " + f);
        material.SetFloat("_ColorStart", f);
        
    }
    public void ColorEnd(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>();       
        Debug.Log("Color End : " + f);
        material.SetFloat("_ColorEnd", f);
        
    }



    public void ColorShift(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>();        

        f = Utilities.Map(f, 0, 1, -180, 180);
        
        Debug.Log("Color Shift: " + f);
        //colorGrading.hueShift.Override(f);
        //material.SetFloat("_ColorShift", f);

    }



    public void TimeChanged(InputAction.CallbackContext context)
    {

        if (ShouldIgnore(context))
        {
            return;
        }        
        
        tTimeChanged = context.ReadValue<float>() * 5.0f;
        Debug.Log("Timescale: " + tTimeChanged);

        if (! stopped)
        {
            timeScale = tTimeChanged;
            newTime = tTimeChanged;
        }   
        else
        {
            newTime = tTimeChanged;
            timeScale = newTime;
        }     
    }
    float tTimeChanged = 0; 

    public void Forwards(InputAction.CallbackContext context)
    {
        if (elapsed < transitionTime || context.phase != InputActionPhase.Performed)
        {
            return;
        }
        fromDistance = -cam.transform.localPosition.z;
        toDistance = Mathf.Clamp(fromDistance - step, min, max);            
        elapsed = 0;
        transition = Transition.movement;
    }

    public void Backwards(InputAction.CallbackContext context)
    {
        if (elapsed < transitionTime || context.phase != InputActionPhase.Performed)
        {
            return;
        }
        fromDistance = -cam.transform.localPosition.z;
        toDistance = Mathf.Clamp(fromDistance + step, min, max);            
        elapsed = 0;
        transition = Transition.movement;
    }

    public void PitchClock(InputAction.CallbackContext context)
    {
        if (elapsed < transitionTime || context.phase != InputActionPhase.Performed)
        {
            return;
        }
        Debug.Log("Pitch clock");
        from = transform.localRotation;
        Vector3 localRight = from * Vector3.right;
        to = Quaternion.AngleAxis(angle, localRight) * transform.localRotation;
        elapsed = 0;
        transition = Transition.rotation;
    }
    
    public void PitchCount(InputAction.CallbackContext context)
    {
        if (elapsed < transitionTime || context.phase != InputActionPhase.Performed)
        {
            return;
        }
        from = transform.localRotation;
        Vector3 localRight = from * Vector3.right;
        to = Quaternion.AngleAxis(-angle, localRight) * transform.localRotation;
        elapsed = 0;
        transition = Transition.rotation;
    }

    public void YawClock(InputAction.CallbackContext context)
    {
        if (elapsed < transitionTime || context.phase != InputActionPhase.Performed)
        {
            return;
        }
        from = transform.localRotation;
        Vector3 localUp = from * Vector3.up;
        to = Quaternion.AngleAxis(angle,localUp) * transform.localRotation;
        elapsed = 0;
        transition = Transition.rotation;
    }

    public void YawCount(InputAction.CallbackContext context)
    {
        if (elapsed < transitionTime || context.phase != InputActionPhase.Performed)
        {
            return;
        }
        
        from = transform.localRotation;
        Vector3 localUp = from * Vector3.up;
        to = Quaternion.AngleAxis(-angle, localUp) * transform.localRotation;
        elapsed = 0;
        transition = Transition.rotation;
    }

    public void RollClock(InputAction.CallbackContext context)
    {
        if (elapsed < transitionTime || context.phase != InputActionPhase.Performed)
        {
            return;
        }
        from = transform.localRotation;
        Vector3 localForward = from * Vector3.forward;
        to = Quaternion.AngleAxis(angle, localForward) * transform.localRotation;
        elapsed = 0;
        transition = Transition.rotation;
    }

    public void RollCount(InputAction.CallbackContext context)
    {
        if (elapsed < transitionTime || context.phase != InputActionPhase.Performed)
        {
            return;
        }
        from = transform.localRotation;
        Vector3 localForward = from * Vector3.forward;
        to = Quaternion.AngleAxis(-angle, localForward) * transform.localRotation;
        elapsed = 0;
        transition = Transition.rotation;
    }

    public void Radius(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>() * max;
        Debug.Log("Radius: " + f);
        radius = f;
    }



    public void ColorRange(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = 1.0f + context.ReadValue<float>() * 5000;
        Debug.Log("Desired Range: " + f);
        desiredRange = f;
    }

    float desiredRange = 100;

    float desiredShaderTime = 50;

    public void ShaderTime(InputAction.CallbackContext context)
    {
        if (ShouldIgnore(context))
        {
            return;
        }
        float f = context.ReadValue<float>() * 100;
        Debug.Log("Desired Time: " + f);
        desiredShaderTime = f;
    }

    public float timeScale = 1.0f;
    public float radius = 500;

    void Awake()
    {
        //ns = FindObjectOfType<NematodeSchool>();
        //timeScale = 0;
        oldShaderTime = 1;
        oldTime = timeScale;
        cam = Camera.main.transform;
    }
            
    // Start is called before the first frame update
    void Start()
    {
        //float v = 100.0f;
        //RenderSettings.ambientLight = new Color(v,v,v,1);
        elapsed = transitionTime;
        fromDistance = -cam.transform.localPosition.z;
        toDistance = fromDistance;

        //bloom = volume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        //colorGrading = volume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.ColorGrading>();
        //oldTime = timeScale;

        //pc = GameObject.FindObjectOfType<PlayerController>();
        
        newTime = 0;

        Vector3 lp = cam.transform.localPosition;
        CornerCamera.distance = lp.z; 
        cam.transform.localPosition = lp;
        
        //material.SetFloat("_TimeMultiplier", 0);
    }


    // Update is called once per frame
    void Update()
    {       

        //material.SetFloat("_TimeMultiplier", Mathf.Lerp(material.GetFloat("_TimeMultiplier"), desiredShaderTime, Time.deltaTime));
        //material.SetFloat("_PositionScale", Mathf.Lerp(material.GetFloat("_PositionScale"), desiredRange, Time.deltaTime));
        //material.SetFloat("_Alpha", Mathf.Lerp(material.GetFloat("_Alpha"), desiredAlpha, Time.deltaTime));


        //float oldBloom = bloom.intensity.GetValue<float>();
        //float lerpedBloom = Mathf.Lerp(oldBloom, desiredBloom, Time.deltaTime);
        //bloom.intensity.Override(lerpedBloom);

        if (elapsed < transitionTime)
        {
            elapsed += Time.deltaTime;
            if (elapsed > transitionTime)
            {
                elapsed = transitionTime;
            }

            float t = Utilities.Map2(elapsed, 0, transitionTime, 0, 1
                    , ease, 
                    Utilities.EASE.EASE_IN_OUT
                    );
            switch (transition)
            {
                case Transition.movement:
                {
                    float z = Mathf.Lerp(fromDistance, toDistance, t);
                    Vector3 camLocal = cam.transform.localPosition;
                    camLocal.z = -z;
                    cam.transform.localPosition = camLocal;
                    break;
                }
                case Transition.rotation:
                {
                    transform.localRotation = Quaternion.Slerp(from, to, t);
                    break;
                }
                case Transition.time:
                {
                    Debug.Log("New Time: " + newTime);
                    timeScale = Mathf.Lerp(oldTime, newTime, t);         
                    //float timeM = Mathf.Lerp(oldShaderTime, newShaderTime, t);                     
                    //material.SetFloat("_TimeMultiplier", timeM);      
                    if (elapsed == transitionTime)
                    {
                        stopped = ! stopped;
                    }   
                    break;                    
                }                
            }            
        }       
    }
}
