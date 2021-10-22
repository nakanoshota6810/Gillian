using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockColorFunctionBase�̃I�[�o�[���C�h���s��
/// �΃u���b�N���̏������s��
/// </summary>
public class BlockColorFunctionGreen : BlockColorFunctionBase
{
    //�ΐF���w��
    const ColorPallet constColor = ColorPallet.Green;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param �e�N���X�֓n�����g��Renderer�̃C���X�^���X="rr"></param>
    /// <param �e�N���X�֓n�����g��BlockData�̃C���X�^���X="bd"></param>
    public BlockColorFunctionGreen(Renderer rr, BlockData bd) : base(rr, bd)
    {
    }

    /// <summary>
    /// �u���b�N�̐F��ύX
    /// </summary>
    public override void ChangeBlockColor()
    {
        //�u���b�N�̐F��΂ɕς���
        renderer.material.color = Color.green;
    }

    /// <summary>
    /// �ʂƐڐG���̋���
    /// </summary>
    /// <param �ڐG�����="collision"></param>
    public override void HitUpdate(Collision collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        //�ʂƃu���b�N�̐F�������ł���΁A�u���b�N�̃X�e�[�^�X��ʏ���ő҂���ԂɕύX
        if (ball.ballColor == constColor)
        {
            blockData.blockStatus = BlockStatus.Break;
        }
        //�ʂƃu���b�N�̐F���قȂ�ꍇ�́A�����F�ɂȂ�
        else
        {
            blockData.blockColor =
                ball.ballColor == ColorPallet.Blue ? ColorPallet.Cyan : ColorPallet.Yellow;
        }
    }
}