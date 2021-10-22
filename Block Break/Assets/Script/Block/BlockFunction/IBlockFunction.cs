using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックのステータス毎のインターフェース
/// </summary>
public interface IBlockFunction
{
    public void ItStart();
    public void ItUpdate();
    public void ItCollisionEnter(Collision collision);

}
