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

    //ゲーム開始時に表示するUIを設定
    [SerializeField] private GameObject gameStartUI;

    //ゲームオーバー時に表示するUIを設定
    [SerializeField] private GameObject gameScoreUI;

    //ゲーム開始前にブロックが落ちて来ないよう、物理的に塞ぐプレートを設定
    [SerializeField] private GameObject readyObject;

    private void Start()
    {
        //ゲーム開始時はゲームステータスを準備状態にする
        statusNo = MainGameStatus.Ready;

        //スコアの初期化
        Score.ResetScore();

        //内部時間の初期化
        InternalTime.TimeReset();

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
        }

        //ゲームオーバー時に、ゲームオーバーUIを表示
        if (statusNo == MainGameStatus.GameOver) gameScoreUI.SetActive(true);

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
}
