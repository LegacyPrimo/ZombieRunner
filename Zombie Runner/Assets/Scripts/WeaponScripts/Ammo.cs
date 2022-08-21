using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] ammoSlots;

    // Start is called before the first frame update
    void Start()
    {
        //currentAmmo = maxAmmo;
    }

    public float GetCurrentAmmo(AmmoTypes ammoTypes) 
    {
        return GetAmmoSlot(ammoTypes).ammoAmount;
    }

    public void IncreaseAmmoAmount(AmmoTypes ammoTypes, float ammoAmount) 
    {
        GetAmmoSlot(ammoTypes).ammoAmount += ammoAmount;
    }

    public void DecreaseAmmoAmount(AmmoTypes ammoTypes) 
    {
        GetAmmoSlot(ammoTypes).ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoTypes ammoType) 
    {
        foreach (AmmoSlot slot in ammoSlots) 
        {
            if (slot.ammoTypes == ammoType) 
            {
                return slot;
            }
        }

        return null;
    }


    [System.Serializable]
    private class AmmoSlot 
    {
        public AmmoTypes ammoTypes;
        public float ammoAmount;
    }
}
