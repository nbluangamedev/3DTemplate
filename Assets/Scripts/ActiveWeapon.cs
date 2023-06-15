using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crosshairTarget;
    public Rig handIK;
    public Transform weaponParent;

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
        }
        else
        {
            handIK.weight = 0f;
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
        handIK.weight = 1f;
    }
}