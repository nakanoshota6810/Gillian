using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内時間を管理
/// </summary>
static public class InternalTime
{
    //ゲーム内時間を格納する変数を宣言
    static private float gameInternalTime;

    /// <summary>
    /// 内部時間を返す
    /// </summary>
    /// <returns></returns>
    static public float GetTime()
    {
        return gameInternalTime;
    }

    /// <summary>
    /// 内部時間をリセットする
    /// </summary>
    static public void TimeReset()
    {
        gameInternalTime = 0.0f;
    }

    /// <summary>
    /// 内部時間の更新
    /// </summary>
    static public void TimeUpdate()
    {
        gameInternalTime += Time.deltaTime;

        if (gameInternalTime > 3600.0f) TimeReset();
    }
}
