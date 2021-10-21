using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイムカウント機能を管理
/// </summary>
public class TimeCountChack
{
    //カウントダウンを開始する時間を格納する変数を宣言
    private float startTime;

    //計測する秒数を格納する変数を宣言
    private int chackCount;

    /// <summary>
    /// コンストラクタ
    /// インスタンス生成時に、計測する値を渡す
    /// </summary>
    /// <param 計測する秒数="second"></param>
    public TimeCountChack(int second)
    {
        //開始時間を受け取る
        CountReset();

        //計測時間を設定
        chackCount = second;
       
    }

    /// <summary>
    /// 設定した計測時間毎にtrueを返し、そうでなければfalseを返す
    /// </summary>
    /// <returns></returns>
    public bool ChackTime()
    {
        // 計測時間＋開始時間より、現在の時間が進んでいたら、trueを返す
        if (chackCount + startTime < InternalTime.GetTime())
        {
            //開始時間を再設定する
            CountReset();
            return true;
        }

        return false;
    }

    /// <summary>
    /// カウントを0にする処理
    /// </summary>
    public void CountReset()
    {
        //開始時間を再設定する
        startTime = InternalTime.GetTime();
    }


    /// <summary>
    /// コンストラクタ
    /// インスタンス生成時に、計測する値を渡す
    /// </summary>
    /// <param 計測する秒数="second"></param>
    public void SetNewCount(int second)
    {
        //計測時間を設定
        chackCount = second;

        //開始時間を再設定する
        startTime = InternalTime.GetTime();
    }
}
