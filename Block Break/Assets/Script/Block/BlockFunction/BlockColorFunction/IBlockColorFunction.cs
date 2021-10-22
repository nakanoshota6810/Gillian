using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックの色毎のインターフェース
/// </summary>
public interface IBlockColorFunction
{
    //各機能ごとに、ブロックの色を変更する処理
    public void ChangeBlockColor();

    //玉と接触時の色ごとの処理
    public void HitUpdate(Collision collision);
}