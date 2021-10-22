using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockFunctionBaseへオーバーライドを行う
/// ブロックのステータスが「Break」時の処理を行う
/// </summary>
public class BlockFunctionBreak : BlockFunctionBase
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 親クラスへ渡す自身のBlockDataのインスタンス="bd"></param>
    public BlockFunctionBreak(BlockData bd) : base(bd)
    {
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void ItStart()
    {
        //ブロックを非アクティブ状態とする
        blockData.blockActive = false;

        //スコアの加算
        Score.AddScores();
    }

    /// <summary>
    /// 更新処理(未使用)
    /// </summary>
    public override void ItUpdate(){}

    /// <summary>
    /// 当たり判定処理(未使用)
    /// </summary>
    /// <param 当たりの対象="collision"></param>
    public override void ItCollisionEnter(Collision collision){}
}
