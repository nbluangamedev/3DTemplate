using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crosshairTarget;
    public Transform weaponParent;
    public Animator rigController;

    private RaycastWeapon raycastWeapon;
    

    private void Awake()
    {
        RaycastWeapon existWeapon = GetComponentInChildren<RaycastWeapon>();
        if (existWeapon)
        {
            Equip(existWeapon);
        }
    }

    void Update()
    {
        if (raycastWeapon)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                raycastWeapon.StartFiring();
            }

            if (raycastWeapon.isFiring)
            {
                raycastWeapon.UpdateFiring(Time.deltaTime);
            }

            raycastWeapon.UpdateBullets(Time.deltaTime);

            if (Input.GetButtonUp("Fire1"))
            {
                raycastWeapon.StopFiring();
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                bool isHolstered = rigController.GetBool("holster_weapon");
                rigController.SetBool("holster_weapon", !isHolstered);
            }
        }
    }

    public void Equip(RaycastWeapon newWeapon)
    {
        if (raycastWeapon)
        {
            Destroy(raycastWeapon.gameObject);
        }
        raycastWeapon = newWeapon;
        raycastWeapon.raycastDestination = crosshairTarget;
        raycastWeapon.transform.parent = weaponParent;
        raycastWeapon.transform.localPosition = Vector3.zero;
        raycastWeapon.transform.localRotation = Quaternion.identity;
        rigController.Play("equip_" + raycastWeapon.weaponName);
    }
}