using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionSpown : BlockFunctionBase
{
    //Rigidboby���i�[����ϐ���錾
    private Rigidbody rigidbody;

    //�u���b�N�̃X�|�[����Ԃ̈ێ�����
    private int blockSpawnTime;


    public BlockFunctionSpown(Rigidbody rb, BlockData bd) :base(bd)
    {
        rigidbody = rb;
    }

    public override void ItStart()
    {
        //�݉��܂ł̒l��������
        blockSpawnTime = 3000;

        rigidbody.drag = 0;
    }

    public override void ItUpdate()
    {
        blockSpawnTime--;
        if (blockSpawnTime <= 0)
        {
            //�^�O�ƃ��C���[��ݑ��p�̂��̂ɕύX
            blockData.blockStatus = BlockStatus.Alive;
      
            //�������Ɏ󂯂��C��R�̒l���㏸������
            rigidbody.drag = 6;
        }
    }

    public override void ItCollisionEnter(Collision collision)
    {
        //�u���b�N��SpawnLine�𒴂�����A�������x��ݑ��ɂ���
        if (collision.gameObject.tag == "SpownLine")
        {
            //�^�O�ƃ��C���[��ݑ��p�̂��̂ɕύX
            blockData.blockStatus = BlockStatus.Alive;

            //�������Ɏ󂯂��C��R�̒l���㏸������           
            rigidbody.drag = 6;
        }
    }
}
