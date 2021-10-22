using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックの色スタータス毎の機能を管理する
/// </summary>
public class BlockFunction : IBlockFunction
{
    //ブロックのステータス毎の機能の親クラス
    private BlockFunctionBase blockFunctionBase;

    //ブロックのRigidbodyを格納する
    private Rigidbody   rigidbody;

    //ブロックのRendererを格納する
    private Renderer    renderer;

    //ブロックのBlockDataを格納する
    private BlockData   blockData;

    //ブロックの色ごとの処理の管理クラス
    private BlockColorFunction blockColorFunction;

    //ブロックのステータスの変更を感知する変数の宣言
    BlockStatus nowStatus;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 自身のRigidbodyのインスタンス="rb"></param>
    /// <param 自身のRendererのインスタンス="rr"></param>
    /// <param 自身のBlockDataのインスタンス="bd"></param>
    public BlockFunction(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody   = rb;
        renderer    = rr;
        blockData   = bd;

        blockColorFunction = new BlockColorFunction(renderer, blockData);

        //ブロックをアクティブ状態に変更
        BlockInstantiate();
    }

    /// <summary>
    /// 各ステータス毎の機能の初期化処理
    /// </summary>
    public void ItStart() 
    {
        blockFunctionBase.ItStart();
    }

    /// <summary>
    /// 各ステータス毎の機能の更新処理
    /// </summary>
    public void ItUpdate()
    {
        //ゲームステータスの変更が行われたら、機能を変更する
        if (nowStatus != blockData.blockStatus)
            ChangeBlockFunction();

        if (blockFunctionBase != null)
            blockFunctionBase.ItUpdate();

        //色毎の更新処理を行う
        blockColorFunction.ItUpdate();
    }

   /// <summary>
   /// ステータス毎の当たり判定処理
   /// </summary>
   /// <param 玉の当たり判定="collision"></param>
    public void ItCollisionEnter(Collision collision)
    {
        if (blockFunctionBase != null)
            blockFunctionBase.ItCollisionEnter(collision);
    }

    /// <summary>
    /// アクティブ状態に切り替わった時の初期化処理
    /// </summary>
    public void BlockInstantiate()
    {
        //各ブロックのステータスを初期化
        blockData.blockActive   = true;
        blockData.blockStatus   = BlockStatus.Spawn;
        blockData.blockTag      = "SpawnBlock";
        blockData.blockLayerNo  = 7;

        //ステータス毎の機能の変更
        ChangeBlockFunction();

        //色毎の機能の初期化
        blockColorFunction.StartChangeColor();
    }

    /// <summary>
    /// ブロックのステータス毎に、BlockFunctionBaseへオーバーライドする
    /// </summary>
    private void ChangeBlockFunction()
    {
        blockFunctionBase = null;

        switch (blockData.blockStatus)
        {
            case BlockStatus.Spawn:
                blockFunctionBase = new BlockFunctionSpawn(rigidbody, blockData);
                ItStart();
                break;

            case BlockStatus.Alive:
                blockFunctionBase = new BlockFunctionAlive(blockData, blockColorFunction);
                ItStart();
                break;

            case BlockStatus.Break:
                blockFunctionBase = new BlockFunctionBreak(blockData);
                ItStart();
                break;

            case BlockStatus.SuperBreak:
                blockFunctionBase = new BlockFunctionSuperBreak(blockData);
                ItStart();
                break;

            default:
                blockData.blockStatus = BlockStatus.None;
                break;
        }

        nowStatus = blockData.blockStatus;
    }
}
