using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private float ammoAmount;
    [SerializeField] private AmmoTypes ammoTypes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<Ammo>().IncreaseAmmoAmount(ammoTypes, ammoAmount);
            Destroy(gameObject, 0.1f);
        }
    }
}
