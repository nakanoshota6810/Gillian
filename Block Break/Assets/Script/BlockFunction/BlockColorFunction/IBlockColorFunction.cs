using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockColorFunction
{
    public void ChangeBlockColor();

    public void UpdateBlockStatusFromColor(Collision collision);
}

