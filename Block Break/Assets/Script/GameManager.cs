using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// ゲーム全体の管理機能
/// </summary>
public class GameManager:MonoBehaviour
{
    //ゲームステータスを格納する変数を宣言
    static public MainGameStatus statusNo { get; set; }

    //ゲームモードを格納する変数を宣言
    static public GameMode gameMode { get; set; }

    //gゲーム選択画面時に表示するUIを格納
    [SerializeField] private GameObject gameTitleUI;

    //ゲーム開始時に表示するUIを格納
    [SerializeField] private GameObject gameStartUI;

    //ゲームオーバー時に表示するUIを格納
    [SerializeField] private GameObject gameResultScoreUI;

    //ゲーム中に表示するUIを格納
    [SerializeField] private GameObject gameInPlayScoreUI;

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
        statusNo = MainGameStatus.Title;

        //スコアの初期化
        Score.ResetScore();

        //内部時間の初期化
        InternalTime.TimeReset();

        gameMode = 0;

    }

    void Update()
    {
        //ゲーム開始時のUIなどを削除
        if (statusNo == MainGameStatus.InGameNormal)
        {
            //UIの削除
            gameStartUI.SetActive(false);

            //ブロックが落ちないように塞いでいるプレートを撤去
            readyObject.SetActive(false);

            Score.UpdateChackComboAlive();

            gameInPlayScoreUI.SetActive(true);
        }
        else if(statusNo == MainGameStatus.InGameWarning)
        {
            gameInPlayScoreUI.SetActive(true);
        }
        else
        {
            gameInPlayScoreUI.SetActive(false);
        }

        //ゲームオーバー時に、ゲームオーバーUIを表示
        if (statusNo == MainGameStatus.GameOver) gameResultScoreUI.SetActive(true);

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
        statusNo = MainGameStatus.Ready;
        gameTitleUI.SetActive(false);
        gameStartUI.SetActive(true);
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
        flashingLine.transform.localScale = new Vector3(40, 1, 0.1f);
    }
}
