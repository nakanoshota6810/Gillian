using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// ゲーム全体の管理機能
/// </summary>
public class GameManager:MonoBehaviour
{
    //ゲームステータスを静的に格納する変数を宣言
    static public GameStatus gameStatus { get; set; }

    //ゲームモードを静的に格納する変数を宣言
    static public GameMode gameMode { get; set; }

    //ゲーム開始前にブロックが落ちて来ないよう、物理的に塞ぐプレートを設定
    [SerializeField] private GameObject readyObject;

    //ゲームの左右の壁を格納
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;

    //危険ラインを格納
    [SerializeField] private GameObject flashingLine;

    private void Start()
    {
        //ゲーム開始時はゲームステータスをゲーム選択状態にする
        gameStatus = GameStatus.Title;

        //スコアの初期化
        Score.ResetScore();

        //内部時間の初期化
        InternalTime.TimeReset();

        gameMode = 0;

    }

    void Update()
    {
        //ゲーム開始時のUIなどを削除
        if (gameStatus == GameStatus.InGameNormal)
        {
            //ブロックが落ちないように塞いでいるプレートを撤去
            readyObject.SetActive(false);

            Score.UpdateChackComboAlive();
        }

        //内部時間の更新
        InternalTime.TimeUpdate();
    }

    /// <summary>
    /// リトライさせる
    /// </summary>
    public void Retry()
    {
        //MainGameシーンを再読み込み
        SceneManager.LoadScene("MainGame");
    }

    //ゲームモード選択後、開始準備に移行
    public void GameStart()
    {
        gameStatus = GameStatus.Ready;
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// 通常ゲームモード
    /// </summary>
    public void SetNormalMode()
    {
        gameMode = GameMode.NormalMode;
    }

    /// <summary>
    /// タイムカラーゲームモード
    /// </summary>
    public void SetTimeColorMode()
    {
        gameMode = GameMode.TimeColorMode;
    }

    /// <summary>
    /// ワイドゲームモード
    /// </summary>
    public void SetWideMode()
    {
        gameMode = GameMode.WideMode;
        leftWall.transform.position = new Vector3(-85, 0, 0);
        rightWall.transform.position = new Vector3(85, 0, 0);
        flashingLine.transform.localScale = new Vector3(18, 1, 0.1f);
    }
}
