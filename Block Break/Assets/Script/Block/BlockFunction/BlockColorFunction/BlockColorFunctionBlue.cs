using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockColorFunctionBaseのオーバーライドを行う
/// 青ブロック時の処理を行う
/// </summary>
public class BlockColorFunctionBlue : BlockColorFunctionBase
{
    //青色を指定
    const ColorPallet constColor = ColorPallet.Blue;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 親クラスへ渡す自身のRendererのインスタンス="rr"></param>
    /// <param 親クラスへ渡す自身のBlockDataのインスタンス="bd"></param>
    public BlockColorFunctionBlue(Renderer rr, BlockData bd) : base(rr, bd)
    {
    }

    /// <summary>
    /// ブロックの色を変更
    /// </summary>
    public override void ChangeBlockColor()
    {
        //ブロックの色を青に変える
        renderer.material.color = Color.blue;
    }

    /// <summary>
    /// 玉と接触時の挙動
    /// </summary>
    /// <param 接触する玉="collision"></param>
    public override void HitUpdate(Collision collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        //玉とブロックの色が同じであれば、ブロックのステータスを通常消滅待ち状態に変更
        if (ball.ballColor == constColor)
        {
            blockData.blockStatus = BlockStatus.Break;
        }
        //玉とブロックの色が異なる場合は、混合色にする
        else
        {
            blockData.blockColor =
                ball.ballColor == ColorPallet.Red ? ColorPallet.Magenta : ColorPallet.Cyan;
        }
    }
}