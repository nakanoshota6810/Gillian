using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorFunctionMagenta : BlockColorFunctionBase
{
    //�}�[���^�F���w��
    const ColorPallet constColor = ColorPallet.Magenta;
    const ColorPallet constNextWhiteColor = ColorPallet.Green;

    public BlockColorFunctionMagenta(Renderer rr, BlockData bd) : base(rr, bd)
    {
    }

    /// <summary>
    /// �u���b�N�̐F��ύX
    /// </summary>
    public override void ChangeBlockColor()
    {
        renderer.material.color = Color.magenta;
    }

    /// <summary>
    /// �ʂƐڐG���̋���
    /// </summary>
    /// <param �ڐG�����="collision"></param>
    public override void UpdateBlockStatusFromColor(Collision collision)
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