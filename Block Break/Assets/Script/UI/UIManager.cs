using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームステータスごとのUIの管理
/// </summary>
public class UIManager
{
    //ゲーム選択画面時に表示するUIを格納
    [SerializeField] private GameObject gameTitleUI;

    //ゲーム開始時に表示するUIを格納
    [SerializeField] private GameObject gameStartUI;

    //ゲームオーバー時に表示するUIを格納
    [SerializeField] private GameObject gameResultScoreUI;

    //ゲーム中に表示するUIを格納
    [SerializeField] private GameObject gameInPlayScoreUI;

    //ゲームステータスの変更を感知する変数の宣言
    private GameStatus nowGameStatus;

    // Start is called before the first frame update
    void Start()
    {
        nowGameStatus = GameStatus.Nome;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームステータスが変更したときに処理を行う
        if (nowGameStatus != GameManager.gameStatus)
            ChangeUI();
    }

    /// <summary>
    /// ゲームステータスごとにUIの切り替えを行う
    /// </summary>
    void ChangeUI()
    {
        switch (GameManager.gameStatus)
        {
            case GameStatus.Title:
                gameTitleUI.SetActive(true);
                break;

            case GameStatus.Ready:
                gameTitleUI.SetActive(false);
                gameStartUI.SetActive(true);
                break;

            case GameStatus.InGameNormal:
                gameStartUI.SetActive(false);
                gameInPlayScoreUI.SetActive(true);
                break;

            case GameStatus.InGameWarning:
                break;

            case GameStatus.GameOver:
                gameInPlayScoreUI.SetActive(false);
                gameResultScoreUI.SetActive(true);
                break;

            default:
                break;
        }

        nowGameStatus = GameManager.gameStatus;
    }
}
