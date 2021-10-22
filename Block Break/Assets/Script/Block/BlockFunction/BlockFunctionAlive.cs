using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionAlive : BlockFunctionBase
{
    private BlockColorFunction blockColorFunction;


    //衝撃波用に上下左右のベクトル方向を格納する変数を宣言
    private Vector3[] effectVector;


    public BlockFunctionAlive(BlockData bd, BlockColorFunction bcf) : base(bd)
    {
        blockColorFunction = bcf;
    }

    public override void ItStart()
    {
        blockData.blockTag = "AliveBlock";
        blockData.blockLayerNo = 6;
    }

    public override void ItUpdate()
    {
    }

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
            blockColorFunction.UpdateBlockStatusFromColor(collision);
        }
    }
}
