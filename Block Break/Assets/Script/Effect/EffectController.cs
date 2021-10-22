using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�[�p�[�u���C�N���̏Ռ��g�G�t�F�N�g���Ǘ�����
/// </summary>
public class EffectController : MonoBehaviour
{
    //�ړ��X�s�[�h���i�[
    [SerializeField] private float moveSpeed;

    //�ړ��������i�[����
    private Vector3 moveVector;

    // Update is called once per frame
    void Update()
    {
        //�ړ������Ɉړ��X�s�[�h���ړ�
        transform.position += moveVector * moveSpeed;

        //���܂ňړ����邱�ƂŁA�Ռ��g������
        if (transform.position.x < -60 || transform.position.x > 60 || transform.position.y > 80)
            Destroy(this.gameObject);
    }

    /// <summary>
    /// �ړ������Əo���ꏊ���󂯎��
    /// </summary>
    /// <param �ړ�����="moveVec"></param>
    /// <param �o���ꏊ="alivepPosition"></param>
    public void SetVectors(Vector3 moveVec, Vector3 alivepPosition)
    {
        moveVector = moveVec;
        transform.position = alivepPosition;
    }
}

