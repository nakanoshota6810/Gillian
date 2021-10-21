using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    //ブロックのRigidboryを格納する変数を宣言
    private new Rigidbody rigidbody;

    //ブロックのRendererを格納する変数を宣言
    private new Renderer renderer;

    //ブロックのデータを格納する変数を宣言
    private BlockData blockData;

    //ブロックの挙動インターフェースを格納する変数を宣言
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
