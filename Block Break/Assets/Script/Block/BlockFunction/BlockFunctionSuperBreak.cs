using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunctionSuperBreak : BlockFunctionBase
{

    public BlockFunctionSuperBreak(BlockData bd) : base(bd)
    {
    }

    public override void ItStart()
    {
        Score.AddScores();
    }

    public override void ItUpdate()
    {
    }

    public override void ItCollisionEnter(Collision collision)
    {
    }
}
