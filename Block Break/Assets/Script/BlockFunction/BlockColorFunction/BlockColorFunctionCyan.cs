using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorFunctionCyan : BlockColorFunctionBase
{
    //�V�A���F���w��
    const ColorPallet constColor = ColorPallet.Cyan;
    const ColorPallet constNextWhiteColor = ColorPallet.Red;

    public BlockColorFunctionCyan(Renderer rr, BlockData bd) : base(rr, bd)
    { 
    }

    /// <summary>
    /// �u���b�N�̐F��ύX
    /// </summary>
    public override void ChangeBlockColor()
    {
        renderer.material.color = Color.cyan;
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