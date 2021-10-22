using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockColorFunctionBaseのオーバーライドを行う
/// シアンブロック時の処理を行う
/// </summary>
public class BlockColorFunctionCyan : BlockColorFunctionBase
{
    //シアン色を指定
    const ColorPallet constColor = ColorPallet.Cyan;
    const ColorPallet constNextWhiteColor = ColorPallet.Red;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 親クラスへ渡す自身のRendererのインスタンス="rr"></param>
    /// <param 親クラスへ渡す自身のBlockDataのインスタンス="bd"></param>
    public BlockColorFunctionCyan(Renderer rr, BlockData bd) : base(rr, bd)
    { 
    }

    /// <summary>
    /// ブロックの色を変更
    /// </summary>
    public override void ChangeBlockColor()
    {
        //ブロックの色をシアンに変える
        renderer.material.color = Color.cyan;
    }

    /// <summary>
    /// 玉と接触時の挙動
    /// </summary>
    /// <param 接触する玉="collision"></param>
    public override void HitUpdate(Collision collision)
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