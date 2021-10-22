using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックのステータス毎の機能の親クラス
/// </summary>
public abstract class BlockFunctionBase : IBlockFunction
{
    protected BlockData blockData;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 自身のBlockDataのインスタンス="bd"></param>
    public BlockFunctionBase(BlockData bd)
    {
        blockData = bd;
    }

    public abstract void ItStart();
    public abstract void ItUpdate();
    public abstract void ItCollisionEnter(Collision collision);
}
