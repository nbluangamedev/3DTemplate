using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseManager<GameManager>
{
    private void Start()
    {
        if (UIManager.HasInstance)
        {
            //UIManager.Instance.ShowScreen<ScreenMenu>();

            //UserInfo userInfo = new UserInfo { userName = "Thuc" };
            //UIManager.Instance.ShowScreen<ScreenMenu>(userInfo,true);
            UIManager.Instance.GetExistScreen<ScreenMenu>().Hide();
        }
    }
}
