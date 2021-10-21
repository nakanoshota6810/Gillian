using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionAlive : BlockFunctionBase
{
    private BlockColorFunction blockColorFunction;


    //�Ռ��g�p�ɏ㉺���E�̃x�N�g���������i�[����ϐ���錾
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
        //�Ռ��g�ɐڐG���A�u���b�N�����ł�����
        if (collision.gameObject.tag == "Effect")
        {
            //�u���b�N�̃X�e�[�^�X���A�ʏ���ő҂���Ԃɂ���
            blockData.blockStatus = BlockStatus.Break;
        }

        //�ʂƐڐG���̂ݏ����ɓ���
        if (collision.gameObject.tag == "Player")
        {
            //�F��񂲂ƂɃu���b�N�̃X�e�[�^�X��ύX����
            blockColorFunction.UpdateBlockStatusFromColor(collision);
        }
    }
}
