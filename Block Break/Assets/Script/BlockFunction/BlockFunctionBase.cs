using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockFunctionBase : IBlockFunction
{
    protected BlockData blockData;

    public BlockFunctionBase(BlockData bd)
    {
        blockData = bd;
    }

    public abstract void ItStart();
    public abstract void ItUpdate();
    public abstract void ItCollisionEnter(Collision collision);
}
