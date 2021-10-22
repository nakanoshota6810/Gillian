using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockFunctionBaseへオーバーライドを行う
/// ブロックのステータスが「Spawn」時の処理を行う
/// </summary>
public class BlockFunctionSpawn : BlockFunctionBase
{
    //Rigidbobyを格納する変数を宣言
    private Rigidbody rigidbody;

    //ブロックのスポーン状態の維持時間
    private Timer blockSpawnTime;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 親クラスへ渡す自身のBlockDataのインスタンス="bd"></param>
    /// <param 自身のRigidbodyのインスタンス="bcf"></param>
    public BlockFunctionSpawn(Rigidbody rb, BlockData bd) :base(bd)
    {
        rigidbody = rb;
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void ItStart()
    {
        

        rigidbody.drag = 0;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public override void ItUpdate()
    {
        //インゲーム中に鈍足化タイマーが動く
        if (GameManager.gameStatus == GameStatus.InGameNormal && blockSpawnTime != null)
        {
            //鈍化までの値を初期化
            blockSpawnTime = new Timer(5);
        }

        if (blockSpawnTime == null) return;

        if (blockSpawnTime.ChackTime())
        {
            //タグとレイヤーを鈍足用のものに変更
            blockData.blockStatus = BlockStatus.Alive;
      
            //落下時に受ける空気抵抗の値を上昇させる
            rigidbody.drag = 6;
        }
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    /// <param 当たりの対象="collision"></param>
    public override void ItCollisionEnter(Collision collision)
    {
        //ブロックがSpawnLineを超えたら、落下速度を鈍足にする
        if (collision.gameObject.tag == "SpawnLine")
        {
            //タグとレイヤーを鈍足用のものに変更
            blockData.blockStatus = BlockStatus.Alive;

            //落下時に受ける空気抵抗の値を上昇させる           
            rigidbody.drag = 6;
        }
    }
}
