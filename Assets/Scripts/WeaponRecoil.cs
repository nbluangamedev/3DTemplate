using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector] public CinemachineFreeLook playerCamera;
    [HideInInspector] public CinemachineImpulseSource cameraShake;

    public Vector2[] recoilPattern;        
    public float duration;

    private float time;
    private int index;
    private float verticalRecoil;
    private float horizontalRecoil;

    private void Awake()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }

    public void GenerateRecoil()
    {
        time = duration;
        cameraShake.GenerateImpulse(Camera.main.transform.forward);
        
        horizontalRecoil = recoilPattern[index].x;
        verticalRecoil = recoilPattern[index].y;

        index = NextIndex(index);
    }

    private int NextIndex(int index)
    {
        return (index + 1) % recoilPattern.Length;
    }

    private void Update()
    {
        if (time > 0)
        {
            playerCamera.m_YAxis.Value -= ((verticalRecoil/1000) * Time.deltaTime)/duration;
            playerCamera.m_XAxis.Value -= ((horizontalRecoil / 10) * Time.deltaTime) / duration;
            time -= Time.deltaTime;
        }
    }
}