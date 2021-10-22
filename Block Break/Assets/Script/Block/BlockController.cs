using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックの機能を管理する
/// </summary>
public class BlockController
{
    //ブロックのRigidboryを格納する変数を宣言
    private Rigidbody rigidbody;

    //ブロックのRendererを格納する変数を宣言
    private Renderer renderer;

    //ブロックのデータを格納する変数を宣言
    private BlockData blockData;

    //ブロックの挙動クラスのインスタンスを格納する変数を宣言
    BlockFunction blockFunction;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 自身のRigidbodyのインスタンス="rb"></param>
    /// <param 自身のRendererのインスタンス="rr"></param>
    /// <param 自身のBlockDataのインスタンス="bd"></param>
    public BlockController(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody   = rb;
        renderer    = rr;
        blockData   = bd;

        //ブロックの挙動クラスをインスタンス化
        blockFunction = new BlockFunction(rigidbody, renderer, blockData);
    }

    /// <summary>
    /// ブロックがアクティブ状態になった時の処理
    /// </summary>
    public void BlockInstantiate()
    {
        blockFunction.BlockInstantiate();
    }

    /// <summary>
    /// ブロックの更新処理
    /// </summary>
    public void ItUpdate()
    {
        blockFunction.ItUpdate();
    }

    /// <summary>
    /// ブロックの当たり判定処理
    /// </summary>
    /// <param 当たり判定="collision"></param>
    public void ItCollisionEnter(Collision collision)
    {
        blockFunction.ItCollisionEnter(collision);
    }
   
}
