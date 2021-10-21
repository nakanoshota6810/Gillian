using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorFunctionMagenta : BlockColorFunctionBase
{
    //マゼンタ色を指定
    const ColorPallet constColor = ColorPallet.Magenta;
    const ColorPallet constNextWhiteColor = ColorPallet.Green;

    public BlockColorFunctionMagenta(Renderer rr, BlockData bd) : base(rr, bd)
    {
    }

    /// <summary>
    /// ブロックの色を変更
    /// </summary>
    public override void ChangeBlockColor()
    {
        renderer.material.color = Color.magenta;
    }

    /// <summary>
    /// 玉と接触時の挙動
    /// </summary>
    /// <param 接触する玉="collision"></param>
    public override void UpdateBlockStatusFromColor(Collision collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        //玉の色が青であれば、ブロックは衝撃波を飛ばす
        if (ball.ballColor == constNextWhiteColor)
        {
            //ブロックのステータスを衝撃波混みの消滅待ち状態とする
            blockData.blockStatus = BlockStatus.SuperBreak;
        }
    }
}