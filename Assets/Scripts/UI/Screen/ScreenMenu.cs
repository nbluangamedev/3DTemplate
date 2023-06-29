using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenMenu : BaseScreen
{
    public TextMeshProUGUI userName;

    public override void Show(object data)
    {
        base.Show(data);

        if(data != null)
        {
            //if(data is UserInfo info)
            //{
            //    userName.text = info.userName;
            //}
        }
    }

    public override void Hide()
    {
        base.Hide();
    }
}
