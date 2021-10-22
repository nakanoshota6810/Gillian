using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockFunctionBase�փI�[�o�[���C�h���s��
/// �u���b�N�̃X�e�[�^�X���uBreak�v���̏������s��
/// </summary>
public class BlockFunctionBreak : BlockFunctionBase
{
    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param �e�N���X�֓n�����g��BlockData�̃C���X�^���X="bd"></param>
    public BlockFunctionBreak(BlockData bd) : base(bd)
    {
    }

    /// <summary>
    /// ����������
    /// </summary>
    public override void ItStart()
    {
        //�u���b�N���A�N�e�B�u��ԂƂ���
        blockData.blockActive = false;

        //�X�R�A�̉��Z
        Score.AddScores();
    }

    /// <summary>
    /// �X�V����(���g�p)
    /// </summary>
    public override void ItUpdate(){}

    /// <summary>
    /// �����蔻�菈��(���g�p)
    /// </summary>
    /// <param ������̑Ώ�="collision"></param>
    public override void ItCollisionEnter(Collision collision){}
}
