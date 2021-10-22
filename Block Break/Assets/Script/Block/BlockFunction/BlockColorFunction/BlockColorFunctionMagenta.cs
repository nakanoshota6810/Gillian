using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockColorFunctionBase�̃I�[�o�[���C�h���s��
/// �}�[���^�u���b�N���̏������s��
/// </summary>
public class BlockColorFunctionMagenta : BlockColorFunctionBase
{
    //�}�[���^�F���w��
    const ColorPallet constColor = ColorPallet.Magenta;
    const ColorPallet constNextWhiteColor = ColorPallet.Green;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param �e�N���X�֓n�����g��Renderer�̃C���X�^���X="rr"></param>
    /// <param �e�N���X�֓n�����g��BlockData�̃C���X�^���X="bd"></param>
    public BlockColorFunctionMagenta(Renderer rr, BlockData bd) : base(rr, bd)
    {
    }

    /// <summary>
    /// �u���b�N�̐F��ύX
    /// </summary>
    public override void ChangeBlockColor()
    {
        // �u���b�N�̐F���}�[���^�ɕς���
        renderer.material.color = Color.magenta;
    }

    /// <summary>
    /// �ʂƐڐG���̋���
    /// </summary>
    /// <param �ڐG�����="collision"></param>
    public override void HitUpdate(Collision collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        //�ʂ̐F���ł���΁A�u���b�N�͏Ռ��g���΂�
        if (ball.ballColor == constNextWhiteColor)
        {
            //�u���b�N�̃X�e�[�^�X���Ռ��g���݂̏��ő҂���ԂƂ���
            blockData.blockStatus = BlockStatus.SuperBreak;
        }
    }
}