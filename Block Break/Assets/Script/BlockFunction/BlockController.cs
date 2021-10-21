using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    //�u���b�N��Rigidbory���i�[����ϐ���錾
    private new Rigidbody rigidbody;

    //�u���b�N��Renderer���i�[����ϐ���錾
    private new Renderer renderer;

    //�u���b�N�̃f�[�^���i�[����ϐ���錾
    private BlockData blockData;

    //�u���b�N�̋����C���^�[�t�F�[�X���i�[����ϐ���錾
    IBlockFunction blockFunction;

    
    BlockColorFunction blockColorFanction;


    public BlockController(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody = rb;
        renderer = rr;
        blockData = bd;

        blockData.blockStatus = BlockStatus.Fall;

        ChangeBlockFunction();

        blockColorFanction = new BlockColorFunction(renderer, blockData);

    }

    private void ChangeBlockFunction()
    {
        blockFunction = null;

        switch (blockData.blockStatus)
        {
            case BlockStatus.Fall:
                blockFunction = new BlockFunctionSpown(rigidbody, blockData);
                ItStart();
                break;

            case BlockStatus.Alive:
                blockFunction = new BlockFunctionAlive(blockData, blockColorFanction);
                this.tag = "AliveBlock";
                this.gameObject.layer = 6;
                break;
        }
    }

    public void ItStart()
    {
        blockFunction.ItStart();
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
