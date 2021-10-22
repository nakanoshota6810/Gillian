using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockColorFunctionBase�̃I�[�o�[���C�h���s��
/// �C�G���[�u���b�N���̏������s��
/// </summary>
public class BlockColorFunctionYellow : BlockColorFunctionBase
{
    //�C�G���[�F���w��
    const ColorPallet constColor = ColorPallet.Yellow;
    const ColorPallet constNextWhiteColor = ColorPallet.Blue;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param �e�N���X�֓n�����g��Renderer�̃C���X�^���X="rr"></param>
    /// <param �e�N���X�֓n�����g��BlockData�̃C���X�^���X="bd"></param>
    public BlockColorFunctionYellow(Renderer rr, BlockData bd) : base(rr, bd)
    {
    }

    /// <summary>
    /// �u���b�N�̐F��ύX
    /// </summary>
    public override void ChangeBlockColor()
    {
        //�u���b�N�̐F���C�G���[�ɕς���
        renderer.material.color = Color.yellow;
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