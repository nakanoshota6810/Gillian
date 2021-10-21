using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorFunction
{
    BlockColorFunctionBase blockColorFanction;

    private Renderer renderer;

    private BlockData blockData;

    private ColorPallet nowColor;

    public BlockColorFunction(Renderer rr, BlockData bd)
    {
        renderer = rr;
        blockData = bd;
    }

    public void StartChangeColor()
    {
        //生成時にブロックの色をランダムにする
        ChangeBlockColor(Random.Range(0, 3));

        nowColor = blockData.blockColor;

        ChangeBlockColorFunction();
    }

    public void ChangeBlockColor(ColorPallet color)
    {
        blockData.blockColor = color; 
    }

    public void ChangeBlockColor(int color)
    {
        blockData.blockColor = (ColorPallet)(color + 1);
    }

    public void ItUpdate()
    {
        if (nowColor != blockData.blockColor)
            ChangeBlockColorFunction();
    }

    public void UpdateBlockStatusFromColor(Collision collision)
    {
        if (blockColorFanction != null)
            blockColorFanction.UpdateBlockStatusFromColor(collision);
    }

    private void ChangeBlockColorFunction()
    {
        switch (blockData.blockColor)
        {
            case ColorPallet.Red:
                if (blockColorFanction as BlockColorFunctionRed == null)
                {
                    blockColorFanction = null;
                    blockColorFanction = new BlockColorFunctionRed(renderer, blockData);
                }
                break;

            case ColorPallet.Green:
                if (blockColorFanction as BlockColorFunctionGreen == null)
                {
                    blockColorFanction = null;
                    blockColorFanction = new BlockColorFunctionGreen(renderer, blockData);
                }
                break;

            case ColorPallet.Blue:
                if (blockColorFanction as BlockColorFunctionBlue == null)
                {
                    blockColorFanction = null;
                    blockColorFanction = new BlockColorFunctionBlue(renderer, blockData);
                }
                break;

            case ColorPallet.Yellow:
                if (blockColorFanction as BlockColorFunctionYellow == null)
                {
                    blockColorFanction = null;
                    blockColorFanction = new BlockColorFunctionYellow(renderer, blockData);
                }
                break;

            case ColorPallet.Magenta:
                if (blockColorFanction as BlockColorFunctionMagenta == null)
                {
                    blockColorFanction = null;
                    blockColorFanction = new BlockColorFunctionMagenta(renderer, blockData);
                }
                break;

            case ColorPallet.Cyan:
                if (blockColorFanction as BlockColorFunctionCyan == null)
                {
                    blockColorFanction = null;
                    blockColorFanction = new BlockColorFunctionCyan(renderer, blockData);
                }
                break;

            default:
                blockColorFanction = null;
                break;
        }

        if (blockColorFanction != null) blockColorFanction.ChangeBlockColor();
         nowColor = blockData.blockColor;
    }
}
