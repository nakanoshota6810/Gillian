using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockColorFanction
{
    public void ItCollisionEnterEffect(BlockData blockData);
    public void ItCollisionEnterPlayer(Collision collision, BlockData blockData);
}


public class BlockHitFanctionRed : IBlockColorFanction
{
    const ColorPallet constColor= ColorPallet.Red;
    

    public void ItCollisionEnterEffect(BlockData blockData)
    {
        Score.BlockbreakCountAndScorePointAdd();
        blockData.blockActive = false;
    }

    public void ItCollisionEnterPlayer(Collision collision, BlockData blockData)
    {
        //玉とブロックの色が同じであれば、ブロックは消滅
        BallController ball = collision.gameObject.GetComponent<BallController>();
        if (ball.ballColor == constColor)
        {
            Score.BlockbreakCountAndScorePointAdd();
            blockData.blockActive = false;
        }
        else
        {
            blockData.blockColor =
                ball.ballColor == ColorPallet.Green ? ColorPallet.Yellow : ColorPallet.Magenta;

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
