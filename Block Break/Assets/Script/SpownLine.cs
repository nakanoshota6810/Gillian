using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̗������x��݉������@�\
/// ����ɂ���ău���b�N�������ɑf�����������A���U�ŃQ�[���I�[�o�[���C���ɓ��B���Ȃ��悤�ɂ�����B
/// </summary>
public class SpownLine : MonoBehaviour
{
    //�u���b�N���ݑ������郉�C���̏����l���i�[
    [SerializeField] private float lineStratPositionY;

    //�u���b�N���ݑ������郉�C���̉����l���i�[
    [SerializeField] private float lineUnderPositionY;

    // Start is called before the first frame update
    void Start()
    {
        //���C���̍������X�V
        PositionUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        //���X�ɉ����l�܂Ń��C����������
        if (lineStratPositionY > lineUnderPositionY) lineStratPositionY -= 0.01f;

        //���C���̍������X�V
        PositionUpdate();
    }

    /// <summary>
    /// �X�|�[�����C���̍������X�V����
    /// </summary>
    void PositionUpdate()
    {
        Vector3 vec = transform.position;
        vec.y = lineStratPositionY;
        transform.position = vec;
    }
}