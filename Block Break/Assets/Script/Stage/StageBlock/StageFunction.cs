using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ機能群を管理する
/// </summary>
public class StageFunction 
{
    //各ステージ機能の親クラスを宣言
    private StageFunctionBase stageFunctionBase;

    //ゲームステータスの変更を感知する変数の宣言
    GameStatus nowMainGameStatus;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public StageFunction()
    {
        nowMainGameStatus = GameManager.gameStatus;
        stageFunctionBase = null;

        //ステージ機能の切り替え処理
        ChangeGameStatus();
    }

    /// <summary>
    /// ステージ機能の切り替え後の初期化処理
    /// </summary>
    public void ItStart()
    {
        //オーバーライドされていない場合は処理を行わない
        if (stageFunctionBase != null)
            stageFunctionBase.ItStart();
    }

    /// <summary>
    /// ステージ機能ごとの更新処理
    /// </summary>
    public void ItUpdate()
    {
        //ゲームステータスが変更されたとき、ステージ機能を切り替える
        if (nowMainGameStatus != GameManager.gameStatus)
            ChangeGameStatus();
        

        //オーバーライドされていない場合は処理を行わない
        if (stageFunctionBase != null)
            stageFunctionBase.ItUpdate();
    }

    /// <summary>
    /// ゲームステータスごとに、ステージ機能をオーバーライドで切り替えを行う
    /// </summary>
    void ChangeGameStatus()
    {
        stageFunctionBase = null;

        switch (GameManager.gameStatus)
        {
            case GameStatus.Title:
                break;

            case GameStatus.Ready:
                stageFunctionBase = new StageFunctionSetStartBlocks();
                ItStart();
                break;

            case GameStatus.InGameNormal:
                stageFunctionBase = new StageFunctionBlockSpawn();
                ItStart();
                break;

            case GameStatus.InGameWarning:
                break;

            case GameStatus.GameOver:
                break;

            default:
                break;
        }

        nowMainGameStatus = GameManager.gameStatus;

    }
}
