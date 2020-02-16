using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    [SerializeField] float intensityDecreaseTime = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;
    [SerializeField] float maxAngle = 70f;

    float currentIntensity;
    float addedIntensity;

    Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseAngleOverTime();
        DecreaseLightOverTime();
    }

    private void DecreaseAngleOverTime()
    {
         float clampedLightAngle = Mathf.Clamp(light.spotAngle, minAngle, maxAngle);
         light.spotAngle = clampedLightAngle -= angleDecay * Time.deltaTime;
    }

    private void DecreaseLightOverTime()
    {
        light.intensity -= intensityDecreaseTime * Time.deltaTime;
    }

    public void AddIntensityAndAngle(float power, float angle)
    {
        light.intensity += power;
        light.spotAngle += angle;
    }
}
