using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float addAngle;
    [SerializeField] private float addIntensity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            FindObjectOfType<FlashLightSystem>().RestoreLightAngle(addAngle);
            FindObjectOfType<FlashLightSystem>().RestoreLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
