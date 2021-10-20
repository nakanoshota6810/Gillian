using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionAlive : IBlockFunction
{
    private Rigidbody rigidbody;
    private Renderer renderer;
    private BlockData blockData;


    //衝撃波用に上下左右のベクトル方向を格納する変数を宣言
    private Vector3[] effectVector;


    public BlockFunctionAlive(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody = rb;
        renderer = rr;
        blockData = bd;
    }

    public void ItStart()
    {
        //上下左右のベクトルを作成
        effectVector = new Vector3[4];
        effectVector[0] = new Vector3(1, 0, 0);
        effectVector[1] = new Vector3(0, 1, 0);
        effectVector[2] = new Vector3(-1, 0, 0);
        effectVector[3] = new Vector3(0, -1, 0);
    }

    public void ItUpdate()
    {
    }

    public void ItCollisionEnter(Collision collision)
    {
        //衝撃波に接触時、ブロックは消滅
        if (collision.gameObject.tag == "Effect")
        {
            
        }

        //玉と接触時のみ処理に入る
        if (collision.gameObject.tag == "Player")
        {
            //玉とブロックの色が同じであれば、ブロックは消滅
            BallController ball = collision.gameObject.GetComponent<BallController>();
            if (ball.ballColor == blockData.blockColor)
            {
                Score.BlockbreakCountAndScorePointAdd();
                blockData.blockActive = false;
            }
            else
            {
                ////別の色でブロックが単色なら、混合色に変える
                //if (blockColor < 3)
                //{
                //    blockColor += ball.ballColor + 2;
                //    ChangeBlockColor();
                //    return;
                //}

                //////混合色に白になる色の玉がぶつかったら、衝撃波を飛ばす
                //if (blockColor + ball.ballColor + 1 == 6)
                //{
                //    WhiteBlockBreak();
                //    Score.BlockbreakCountAndScorePointAdd();
                //    Destroy(this.gameObject);
                //}
            }
        }
    }
}
