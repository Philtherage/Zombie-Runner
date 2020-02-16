using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleToAdd = 10f;
    [SerializeField] float intensityToAdd = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<FlashLight>().AddIntensityAndAngle(intensityToAdd, angleToAdd);
            Destroy(gameObject);
        }
    }
}
