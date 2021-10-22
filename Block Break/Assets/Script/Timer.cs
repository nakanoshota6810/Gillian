using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������Ԃ𗘗p�����^�C�}�[�@�\
/// </summary>
public class Timer
{
    //�J�E���g�_�E���J�n���̎������i�[����ϐ���錾
    private float startTime;

    //�v������b�����i�[����ϐ���錾
    private int chackCount;

    /// <summary>
    /// �R���X�g���N�^
    /// �C���X�^���X�������ɁA�v������l��n��
    /// </summary>
    /// <param �v������b��="second"></param>
    public Timer(int second)
    {
        //�J�n���Ԃ��󂯎��
        CountReset();

        //�v������b����ݒ�
        chackCount = second;
       
    }

    /// <summary>
    /// Timer��0�ɂȂ��true��Ԃ��A�����łȂ����false��Ԃ�
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
    /// �^�C�}�̊J�n���Ԃ�0�ɂ���
    /// </summary>
    public void CountReset()
    {
        //�J�n���Ԃ��Đݒ肷��
        startTime = InternalTime.GetTime();
    }


    /// <summary>
    /// �v������b�����Đݒ肷��
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
