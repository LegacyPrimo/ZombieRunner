using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private ParticleSystem shootEffect;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float weaponDelay;

    [SerializeField] private bool isDelayedGun;
    [SerializeField] private bool canShoot;

    [SerializeField] private Ammo ammo;
    [SerializeField] private AmmoTypes ammoTypes;
    [SerializeField] private float ammoAmountDecrease;

    private void OnEnable()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FireWeapon();
    }

    private void FireWeapon() 
    {
        if (Input.GetButtonDown("Fire1") && ammo.GetCurrentAmmo(ammoTypes) > 0 && canShoot == true) 
        {
            StartCoroutine(WeaponDelay());
            
        }

    }

    private void ShootWeapon() 
    {

        RaycastHit hit;
        if (Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range))
        {
            shootEffect.Play();
            CreateHitImpact(hit);
            ammo.DecreaseAmmoAmount(ammoTypes);
            Debug.Log(hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) return;
            target.ReduceHitPoints(damage);
        }
        else 
        {
            return;
        }
    }

    private IEnumerator WeaponDelay() 
    {
        
        ShootWeapon();
        canShoot = false;
        yield return new WaitForSeconds(weaponDelay);
        canShoot = true;
    }

    private void CreateHitImpact(RaycastHit hit) 
    {
        GameObject hitEffects = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffects, 2f);
    }
}
