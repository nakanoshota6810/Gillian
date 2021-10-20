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
        //�ʂƃu���b�N�̐F�������ł���΁A�u���b�N�͏���
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

            ////�ʂ̐F�Ńu���b�N���P�F�Ȃ�A�����F�ɕς���
            //if (blockColor < 3)
            //{
            //    blockColor += ball.ballColor + 2;
            //    ChangeBlockColor();
            //    return;
            //}

            //////�����F�ɔ��ɂȂ�F�̋ʂ��Ԃ�������A�Ռ��g���΂�
            //if (blockColor + ball.ballColor + 1 == 6)
            //{
            //    WhiteBlockBreak();
            //    Score.BlockbreakCountAndScorePointAdd();
            //    Destroy(this.gameObject);
            //}
        }
    }
}
