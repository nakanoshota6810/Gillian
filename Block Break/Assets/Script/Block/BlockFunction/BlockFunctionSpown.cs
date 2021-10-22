using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionSpown : BlockFunctionBase
{
    //Rigidbobyを格納する変数を宣言
    private Rigidbody rigidbody;

    //ブロックのスポーン状態の維持時間
    private int blockSpawnTime;


    public BlockFunctionSpown(Rigidbody rb, BlockData bd) :base(bd)
    {
        rigidbody = rb;
    }

    public override void ItStart()
    {
        //鈍化までの値を初期化
        blockSpawnTime = 3000;

        rigidbody.drag = 0;
    }

    public override void ItUpdate()
    {
        blockSpawnTime--;
        if (blockSpawnTime <= 0)
        {
            //タグとレイヤーを鈍足用のものに変更
            blockData.blockStatus = BlockStatus.Alive;
      
            //落下時に受ける空気抵抗の値を上昇させる
            rigidbody.drag = 6;
        }
    }

    public override void ItCollisionEnter(Collision collision)
    {
        //ブロックがSpawnLineを超えたら、落下速度を鈍足にする
        if (collision.gameObject.tag == "SpownLine")
        {
            //タグとレイヤーを鈍足用のものに変更
            blockData.blockStatus = BlockStatus.Alive;

            //落下時に受ける空気抵抗の値を上昇させる           
            rigidbody.drag = 6;
        }
    }
}
