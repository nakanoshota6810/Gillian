using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockColorFunctionBase : IBlockColorFunction
{

    protected Renderer renderer;

    protected BlockData blockData;

    public  BlockColorFunctionBase(Renderer rr, BlockData bd)
    {
        renderer = rr;
        blockData = bd;
    }

    public abstract void ChangeBlockColor();

    public abstract void UpdateBlockStatusFromColor(Collision collision);

}