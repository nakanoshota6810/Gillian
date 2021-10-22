using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockFunctionBaseへオーバーライドを行う
/// ブロックのステータスが「SuperBreak」時の処理を行う
/// </summary>
public class BlockFunctionSuperBreak : BlockFunctionBase
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 親クラスへ渡す自身のBlockDataのインスタンス="bd"></param>
    public BlockFunctionSuperBreak(BlockData bd) : base(bd)
    {
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void ItStart()
    {
        blockData.blockActive = false;
        Score.AddScores();
    }

    /// <summary>
    /// 更新処理(未使用)
    /// </summary>
    public override void ItUpdate() { }

    /// <summary>
    /// 当たり判定処理(未使用)
    /// </summary>
    /// <param 当たりの対象="collision"></param>
    public override void ItCollisionEnter(Collision collision) { }
}
