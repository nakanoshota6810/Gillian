using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内時間を管理
/// </summary>
static public class InternalTime
{
    static private float gameInternalTime;

    static public float GetTime()
    {
        return gameInternalTime;
    }

    static public void TimeReset()
    {
        gameInternalTime = 0.0f;
    }

    static public void TimeUpdate()
    {
        gameInternalTime += Time.deltaTime;

        if (gameInternalTime > 3600.0f) TimeReset();
    }
}
