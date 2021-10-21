using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunction : IBlockFunction
{
    private BlockFunctionBase blockFunction;

    private Rigidbody   rigidbody;

    private Renderer    renderer;

    private BlockData   blockData;

    private BlockColorFunction blockColorFunction;

    BlockStatus nowStatus;

    public BlockFunction(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody   = rb;
        renderer    = rr;
        blockData   = bd;

        blockColorFunction = new BlockColorFunction(renderer, blockData);
        ActiveAlive();

        
    }

    public void ItStart() 
    {
        blockFunction.ItStart();
    }

    public void ItUpdate() 
    {
        if (nowStatus != blockData.blockStatus) 
            ChangeBlockFunction();

        blockFunction.ItUpdate();
        blockColorFunction.ItUpdate();

    }
    public void ItCollisionEnter(Collision collision)
    {
        blockFunction.ItCollisionEnter(collision);
    }

    public void ActiveAlive()
    {
        blockData.blockActive   = true;
        blockData.blockStatus   = BlockStatus.Fall;
        blockData.blockTag      = "SpawnBlock";
        blockData.blockLayerNo  = 7;

        ChangeBlockFunction();
        blockColorFunction.StartChangeColor();
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
                blockFunction = new BlockFunctionAlive(blockData, blockColorFunction);
                ItStart();
                break;

            case BlockStatus.Break:
                blockFunction = new BlockFunctionBreak(blockData);
                ItStart();
                break;

            case BlockStatus.SuperBreak:
                blockFunction = new BlockFunctionSuperBreak(blockData);
                ItStart();
                break;

            default:
                blockData.blockStatus = BlockStatus.None;
                break;
        }

        nowStatus = blockData.blockStatus;
    }
}
