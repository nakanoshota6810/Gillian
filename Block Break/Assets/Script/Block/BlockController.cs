using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController
{
    //�u���b�N��Rigidbory���i�[����ϐ���錾
    private Rigidbody rigidbody;

    //�u���b�N��Renderer���i�[����ϐ���錾
    private Renderer renderer;

    //�u���b�N�̃f�[�^���i�[����ϐ���錾
    private BlockData blockData;

    //�u���b�N�̋����C���^�[�t�F�[�X���i�[����ϐ���錾
    BlockFunction blockFunction;

    public BlockController(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody   = rb;
        renderer    = rr;
        blockData   = bd;

        blockFunction = new BlockFunction(rigidbody, renderer, blockData);
    }

    public void ItStart()
    {
        blockFunction.ActiveAlive();
    }

    public void ItUpdate()
    {
        blockFunction.ItUpdate();
    }

    public void ItCollisionEnter(Collision collision)
    {
        blockFunction.ItCollisionEnter(collision);
    }
   
}
