using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̐F���̃C���^�[�t�F�[�X
/// </summary>
public interface IBlockColorFunction
{
    //�e�@�\���ƂɁA�u���b�N�̐F��ύX���鏈��
    public void ChangeBlockColor();

    //�ʂƐڐG���̐F���Ƃ̏���
    public void HitUpdate(Collision collision);
}