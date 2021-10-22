using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController
{
    //ブロックのRigidboryを格納する変数を宣言
    private Rigidbody rigidbody;

    //ブロックのRendererを格納する変数を宣言
    private Renderer renderer;

    //ブロックのデータを格納する変数を宣言
    private BlockData blockData;

    //ブロックの挙動インターフェースを格納する変数を宣言
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
