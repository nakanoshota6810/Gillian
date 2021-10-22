using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[�������Ԃ��Ǘ�
/// </summary>
static public class InternalTime
{
    //�Q�[�������Ԃ��i�[����ϐ���錾
    static private float gameInternalTime;

    /// <summary>
    /// �������Ԃ�Ԃ�
    /// </summary>
    /// <returns></returns>
    static public float GetTime()
    {
        return gameInternalTime;
    }

    /// <summary>
    /// �������Ԃ����Z�b�g����
    /// </summary>
    static public void TimeReset()
    {
        gameInternalTime = 0.0f;
    }

    /// <summary>
    /// �������Ԃ̍X�V
    /// </summary>
    static public void TimeUpdate()
    {
        gameInternalTime += Time.deltaTime;

        if (gameInternalTime > 3600.0f) TimeReset();
    }
}
