using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionSpown : IBlockFunction
{
    private Rigidbody   rigidbody;
 
    private BlockData   blockData;

    //ブロックのスポーン状態の維持時間
    private int blockSpawnTime;


    public BlockFunctionSpown(Rigidbody rb, BlockData bd) 
    {
        rigidbody = rb;
        blockData = bd;
    }

    public void ItStart()
    {
        //鈍化までの値を初期化
        blockSpawnTime = 3000;
    }

    public void ItUpdate()
    {
        blockSpawnTime--;
        if (blockSpawnTime <= 0)
        {
            //タグとレイヤーを鈍足用のものに変更
            blockData.blockStatus = BlockStatus.Alive;
      
            //落下時に受ける空気抵抗の値を上昇させる
            rigidbody.drag = 6;///のち修正
        }
    }

    public void ItCollisionEnter(Collision collision)
    {
        //ブロックがSpawnLineを超えたら、落下速度を鈍足にする
        if (collision.gameObject.tag == "SpownLine")
        {
            //タグとレイヤーを鈍足用のものに変更
            blockData.blockStatus = BlockStatus.Alive;

            //落下時に受ける空気抵抗の値を上昇させる           
            rigidbody.drag = 6;///のち修正
        }
    }
}
