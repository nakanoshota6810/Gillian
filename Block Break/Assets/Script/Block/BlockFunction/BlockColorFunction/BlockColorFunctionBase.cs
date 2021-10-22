using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックの色ごとの機能の親クラス
/// </summary>
public abstract class BlockColorFunctionBase : IBlockColorFunction
{
    //ブロックのRendererを格納する
    protected Renderer renderer;

    //ブロックのBlockDataを格納する
    protected BlockData blockData;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 自身のRendererのインスタンス="rr"></param>
    /// <param 自身のBlockDataのインスタンス="bd"></param>
    public BlockColorFunctionBase(Renderer rr, BlockData bd)
    {
        renderer = rr;
        blockData = bd;
    }

    /// <summary>
    /// 各機能ごとに、ブロックの色を変更する処理
    /// </summary>
    public abstract void ChangeBlockColor();

    /// <summary>
    /// 玉と接触時の色ごとの処理
    /// </summary>
    /// <param 玉の当たり判定="collision"></param>
    public abstract void HitUpdate(Collision collision);

}