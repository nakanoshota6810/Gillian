using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionAlive : IBlockFunction
{
    private Rigidbody rigidbody;
    private Renderer renderer;
    private BlockData blockData;


    //�Ռ��g�p�ɏ㉺���E�̃x�N�g���������i�[����ϐ���錾
    private Vector3[] effectVector;


    public BlockFunctionAlive(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody = rb;
        renderer = rr;
        blockData = bd;
    }

    public void ItStart()
    {
        //�㉺���E�̃x�N�g�����쐬
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
        //�Ռ��g�ɐڐG���A�u���b�N�͏���
        if (collision.gameObject.tag == "Effect")
        {
            
        }

        //�ʂƐڐG���̂ݏ����ɓ���
        if (collision.gameObject.tag == "Player")
        {
            //�ʂƃu���b�N�̐F�������ł���΁A�u���b�N�͏���
            BallController ball = collision.gameObject.GetComponent<BallController>();
            if (ball.ballColor == blockData.blockColor)
            {
                Score.BlockbreakCountAndScorePointAdd();
                blockData.blockActive = false;
            }
            else
            {
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
}
