using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorFunctionRed : BlockColorFunctionBase
{
    //�ԐF���w��
    const ColorPallet constColor = ColorPallet.Red;

    public BlockColorFunctionRed(Renderer rr, BlockData bd) :base(rr, bd)
    {
    }

    /// <summary>
    /// �u���b�N�̐F��ύX
    /// </summary>
    public override void ChangeBlockColor()
    {
        renderer.material.color = Color.red;
    }

    /// <summary>
    /// �ʂƐڐG���̋���
    /// </summary>
    /// <param �ڐG�����="collision"></param>
    public override void UpdateBlockStatusFromColor(Collision collision)
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
                ball.ballColor == ColorPallet.Green ? ColorPallet.Yellow : ColorPallet.Magenta;
        }
    }
}