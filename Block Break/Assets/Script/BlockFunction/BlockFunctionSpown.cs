using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionSpown : IBlockFunction
{
    private Rigidbody   rigidbody;
 
    private BlockData   blockData;

    //�u���b�N�̃X�|�[����Ԃ̈ێ�����
    private int blockSpawnTime;


    public BlockFunctionSpown(Rigidbody rb, BlockData bd) 
    {
        rigidbody = rb;
        blockData = bd;
    }

    public void ItStart()
    {
        //�݉��܂ł̒l��������
        blockSpawnTime = 3000;
    }

    public void ItUpdate()
    {
        blockSpawnTime--;
        if (blockSpawnTime <= 0)
        {
            //�^�O�ƃ��C���[��ݑ��p�̂��̂ɕύX
            blockData.blockStatus = BlockStatus.Alive;
      
            //�������Ɏ󂯂��C��R�̒l���㏸������
            rigidbody.drag = 6;///�̂��C��
        }
    }

    public void ItCollisionEnter(Collision collision)
    {
        //�u���b�N��SpawnLine�𒴂�����A�������x��ݑ��ɂ���
        if (collision.gameObject.tag == "SpownLine")
        {
            //�^�O�ƃ��C���[��ݑ��p�̂��̂ɕύX
            blockData.blockStatus = BlockStatus.Alive;

            //�������Ɏ󂯂��C��R�̒l���㏸������           
            rigidbody.drag = 6;///�̂��C��
        }
    }
}
