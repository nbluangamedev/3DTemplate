using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : BaseScreen
{
    [SerializeField] private TextMeshProUGUI ammoText;

    private void OnEnable()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.UPDATE_AMMO, OnUpdateAmmo);
        }
    }

    private void OnDisable()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Unregister(ListenType.UPDATE_AMMO, OnUpdateAmmo);
        }
    }

    private void OnUpdateAmmo(object value)
    {
        if(value is int ammo)
        {
            ammoText.text = ammo.ToString();
        }
    }
}
