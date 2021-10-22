using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マウスカーソルの表示を管理する
/// </summary>
public class CursorController
{
    private bool nowVisible;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    // Start is called before the first frame update
    public CursorController()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        nowVisible = Cursor.visible;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    // Update is called once per frame
    public void ItUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    /// <summary>
    /// マウスカーソル表示の切り替え処理
    /// </summary>
    /// <param name="flag"></param>
    public void ChangeCursorVisible(bool flag)
    {
        nowVisible = flag;

        if (Cursor.visible == nowVisible) return;

        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
