using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorFunctionRed : BlockColorFunctionBase
{
    //赤色を指定
    const ColorPallet constColor = ColorPallet.Red;

    public BlockColorFunctionRed(Renderer rr, BlockData bd) :base(rr, bd)
    {
    }

    /// <summary>
    /// ブロックの色を変更
    /// </summary>
    public override void ChangeBlockColor()
    {
        renderer.material.color = Color.red;
    }

    /// <summary>
    /// 玉と接触時の挙動
    /// </summary>
    /// <param 接触する玉="collision"></param>
    public override void UpdateBlockStatusFromColor(Collision collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        //玉とブロックの色が同じであれば、ブロックのステータスを通常消滅待ち状態に変更
        if (ball.ballColor == constColor)
        {
            blockData.blockStatus = BlockStatus.Break;
        }
        //玉とブロックの色が異なる場合は、混合色になる
        else
        {
            blockData.blockColor =
                ball.ballColor == ColorPallet.Green ? ColorPallet.Yellow : ColorPallet.Magenta;
        }
    }
}