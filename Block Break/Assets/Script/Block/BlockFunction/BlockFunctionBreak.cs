using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionBreak : BlockFunctionBase
{
    public BlockFunctionBreak(BlockData bd) : base(bd)
    {
    }

    public override void ItStart()
    {
        blockData.blockActive = false;
        Score.AddScores();
    }

    public override void ItUpdate()
    {
    }

    public override void ItCollisionEnter(Collision collision)
    {
    }
}
