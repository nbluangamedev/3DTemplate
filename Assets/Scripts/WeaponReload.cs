using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Build.Content;
using UnityEngine;

public class WeaponReload : MonoBehaviour
{
    public Animator rigController;
    public WeaponAnimationEvent animationEvent;
    public ActiveWeapon activeWeapon;
    public Transform leftHand;

    GameObject magazineHand;

    private void Start()
    {
        animationEvent.weaponAnimationEvent.AddListener(OnAnimationEvent);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rigController.SetTrigger("reload_weapon");
        }
    }

    private void OnAnimationEvent(string eventName)
    {
        switch (eventName)
        {
            case "detach_magazine":
                DetachMagazine();
                break;
            case "drop_magazine":
                DropMagazine();
                break;
            case "refill_magazine":
                RefillMagazine();
                break;
            case "attach_magazine":
                AttachMagazine();
                break;
        }
    }

    private void DetachMagazine()
    {
        RaycastWeapon weapon = activeWeapon.GetActiveWeapon();
        magazineHand = Instantiate(weapon.magazine, leftHand, true);
        weapon.magazine.SetActive(false);
    }

    private void DropMagazine()
    {
        GameObject droppedMagazine = Instantiate(magazineHand, magazineHand.transform.position, magazineHand.transform.rotation);
        droppedMagazine.transform.localScale = Vector3.one;
        droppedMagazine.AddComponent<Rigidbody>();
        droppedMagazine.AddComponent<BoxCollider>();
        magazineHand.SetActive(false);
    }

    private void RefillMagazine()
    {
        magazineHand.SetActive(true);
    }

    private void AttachMagazine()
    {
        RaycastWeapon weapon = activeWeapon.GetActiveWeapon();
        weapon.magazine.SetActive(true);
        Destroy(magazineHand);
    }
}