using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] private float lightDecay = 0.1f;
    [SerializeField] private float angleDecay = 1f;
    [SerializeField] private float minimumAngle = 40f;

    private Light thisLight;

    private void Awake()
    {
        thisLight = GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle() 
    {
        if (thisLight.spotAngle >= 40f)
        {
            thisLight.spotAngle -= angleDecay * Time.fixedDeltaTime;
        }
        else if (thisLight.spotAngle < 40f) 
        {
            thisLight.spotAngle = minimumAngle;
        }
        
    }

    private void DecreaseLightIntensity() 
    {
        thisLight.intensity -= lightDecay * Time.fixedDeltaTime;
    }

    public void RestoreLightAngle(float restoreAngle) 
    {
        thisLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float intensityAmount) 
    {
        thisLight.intensity += intensityAmount;
    }
}
