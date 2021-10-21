using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C���J�E���g�@�\���Ǘ�
/// </summary>
public class TimeCountChack
{
    //�J�E���g�_�E�����J�n���鎞�Ԃ��i�[����ϐ���錾
    private float startTime;

    //�v������b�����i�[����ϐ���錾
    private int chackCount;

    /// <summary>
    /// �R���X�g���N�^
    /// �C���X�^���X�������ɁA�v������l��n��
    /// </summary>
    /// <param �v������b��="second"></param>
    public TimeCountChack(int second)
    {
        //�J�n���Ԃ��󂯎��
        CountReset();

        //�v�����Ԃ�ݒ�
        chackCount = second;
       
    }

    /// <summary>
    /// �ݒ肵���v�����Ԗ���true��Ԃ��A�����łȂ����false��Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool ChackTime()
    {
        // �v�����ԁ{�J�n���Ԃ��A���݂̎��Ԃ��i��ł�����Atrue��Ԃ�
        if (chackCount + startTime < InternalTime.GetTime())
        {
            //�J�n���Ԃ��Đݒ肷��
            CountReset();
            return true;
        }

        return false;
    }

    /// <summary>
    /// �J�E���g��0�ɂ��鏈��
    /// </summary>
    public void CountReset()
    {
        //�J�n���Ԃ��Đݒ肷��
        startTime = InternalTime.GetTime();
    }


    /// <summary>
    /// �R���X�g���N�^
    /// �C���X�^���X�������ɁA�v������l��n��
    /// </summary>
    /// <param �v������b��="second"></param>
    public void SetNewCount(int second)
    {
        //�v�����Ԃ�ݒ�
        chackCount = second;

        //�J�n���Ԃ��Đݒ肷��
        startTime = InternalTime.GetTime();
    }
}
