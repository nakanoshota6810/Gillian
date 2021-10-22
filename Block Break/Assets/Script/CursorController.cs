using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �}�E�X�J�[�\���̕\�����Ǘ�����
/// </summary>
public class CursorController
{
    private bool nowVisible;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    // Start is called before the first frame update
    public CursorController()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        nowVisible = Cursor.visible;
    }

    /// <summary>
    /// �X�V����
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
    /// �}�E�X�J�[�\���\���̐؂�ւ�����
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
