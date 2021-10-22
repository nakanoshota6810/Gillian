using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockFunctionBase�փI�[�o�[���C�h���s��
/// �u���b�N�̃X�e�[�^�X���uAlive�v���̏������s��
/// </summary>
public class BlockFunctionAlive : BlockFunctionBase
{
    //�g�p����F���̋@�\�C���X�^���X��錾
    private BlockColorFunction blockColorFunction;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param �e�N���X�֓n�����g��BlockData�̃C���X�^���X="bd"></param>
    /// <param ���g��BlockColorFunction�̃C���X�^���X="bcf"></param>
    public BlockFunctionAlive(BlockData bd, BlockColorFunction bcf) : base(bd)
    {
        blockColorFunction = bcf;
    }

    /// <summary>
    /// ����������
    /// </summary>
    public override void ItStart()
    {
        blockData.blockTag = "AliveBlock";
        blockData.blockLayerNo = 6;
    }

    /// <summary>
    /// �X�V����(���g�p)
    /// </summary>
    public override void ItUpdate(){}

    /// <summary>
    /// �����蔻�菈��
    /// </summary>
    /// <param ������̑Ώ�="collision"></param>
    public override void ItCollisionEnter(Collision collision)
    {
        //�Ռ��g�ɐڐG���A�u���b�N�����ł�����
        if (collision.gameObject.tag == "Effect")
        {
            //�u���b�N�̃X�e�[�^�X���A�ʏ���ő҂���Ԃɂ���
            blockData.blockStatus = BlockStatus.Break;
        }

        //�ʂƐڐG���̂ݏ����ɓ���
        if (collision.gameObject.tag == "Player")
        {
            //�F��񂲂ƂɃu���b�N�̃X�e�[�^�X��ύX����
            if (blockColorFunction != null)
                blockColorFunction.HitUpdate(collision);
        }
    }
}
