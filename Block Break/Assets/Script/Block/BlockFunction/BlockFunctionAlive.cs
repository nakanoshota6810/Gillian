using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockFunctionBaseへオーバーライドを行う
/// ブロックのステータスが「Alive」時の処理を行う
/// </summary>
public class BlockFunctionAlive : BlockFunctionBase
{
    //使用する色毎の機能インスタンスを宣言
    private BlockColorFunction blockColorFunction;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 親クラスへ渡す自身のBlockDataのインスタンス="bd"></param>
    /// <param 自身のBlockColorFunctionのインスタンス="bcf"></param>
    public BlockFunctionAlive(BlockData bd, BlockColorFunction bcf) : base(bd)
    {
        blockColorFunction = bcf;
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void ItStart()
    {
        blockData.blockTag = "AliveBlock";
        blockData.blockLayerNo = 6;
    }

    /// <summary>
    /// 更新処理(未使用)
    /// </summary>
    public override void ItUpdate(){}

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    /// <param 当たりの対象="collision"></param>
    public override void ItCollisionEnter(Collision collision)
    {
        //衝撃波に接触時、ブロックを消滅させる
        if (collision.gameObject.tag == "Effect")
        {
            //ブロックのステータスを、通常消滅待ち状態にする
            blockData.blockStatus = BlockStatus.Break;
        }

        //玉と接触時のみ処理に入る
        if (collision.gameObject.tag == "Player")
        {
            //色情報ごとにブロックのステータスを変更する
            if (blockColorFunction != null)
                blockColorFunction.HitUpdate(collision);
        }
    }
}
