using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ機能の親クラス
/// </summary>
public abstract class StageFunctionBase : IStageFunction
{
    public abstract void ItStart();

    public abstract void ItUpdate();

}
