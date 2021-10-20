using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// 
/// Materialの色操作も [IBlockColorFanction]を使用したほうがよさそう
/// 
/// 
/// 
/// </summary>

public class BlockController : MonoBehaviour
{
    //ブロックのRigidboryを格納する変数を宣言
    private new Rigidbody rigidbody;

    //ブロックのRendererを格納する変数を宣言
    private new Renderer renderer;

    private BlockData blockData;

    IBlockFunction blockFunction;
    IBlockColorFanction blockColorFanction;


    public BlockController(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody = rb;
        renderer = rr;
        blockData = bd;

        blockData.blockStatus = BlockStatus.Fall;

        ChangeBlockFunction();
        
    }

    private void ChangeBlockFunction()
    {
        blockFunction = null;

        switch (blockData.blockStatus)
        {
            case BlockStatus.Fall:
                blockFunction = new BlockFunctionSpown(rigidbody, renderer, blockData);
                ItStart();
                break;

            case BlockStatus.Alive:
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
        
    }

    public void ItCollisionEnter()
    {

    }
    

    static public ColorPallet ChangeBlockColor(Renderer rr,int colorNo)
    {
        ColorPallet colorPallet = (ColorPallet)(colorNo + 1);

        switch (colorPallet)
        {
            case ColorPallet.Red:
                rr.material.color = Color.red;
                break;
            
            case ColorPallet.Green:
                rr.material.color = Color.green;
                break;

            case ColorPallet.Blue:
                rr.material.color = Color.blue;
                break;

            case ColorPallet.Yellow:
                rr.material.color = Color.yellow;
                break;

            case ColorPallet.Magenta:
                rr.material.color = Color.magenta;
                break;

            case ColorPallet.Cyan:
                rr.material.color = Color.cyan;
                break;

            default:
                rr.material.color = Color.white;
                break;
        }

        return colorPallet;
    }
}
