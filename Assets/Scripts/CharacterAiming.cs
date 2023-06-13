using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15f;
    public float aimDuration = 0.3f;
    public Rig aimLayer;

    private Camera mainCamera;
    private RaycastWeapon raycastWeapon;

    private void Awake()
    {
        mainCamera = Camera.main;
        raycastWeapon = GetComponentInChildren<RaycastWeapon>();
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (aimLayer)
        {
            if (Input.GetButton("Fire2"))
            {
                aimLayer.weight += Time.deltaTime / aimDuration;
            }
            else
            {
                aimLayer.weight -= Time.deltaTime / aimDuration;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            raycastWeapon.StartFiring();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            raycastWeapon.StopFiring();
        }
    }

    private void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
}