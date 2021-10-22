using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 危険ラインの機能
/// </summary>
public class WarningLine : MonoBehaviour
{
    //ゲームオーバーラインの高さの初期値を設定
    [SerializeField] private float lineUnderPositionY;

    //Renderer型を格納する変数を宣言
    private new Renderer renderer;

    //点滅の基準となるタイムカウントを格納する変数を宣言
    private int flashingTime;

    private void Start()
    {
        //Renderer型のコンポーネントを取得
        renderer = GetComponent<Renderer>();

        //タイムカウントの初期化
        flashingTime = 500;
    }

    void Update()
    {
        //ゲームステータスが危険状態のみ、タイムカウントを動かす
        if (GameManager.gameStatus == GameStatus.InGameWarning) flashingTime--;

        //タイムカウントごとに、テキストを点滅させる
        if (flashingTime <= 0) flashingTime = 500;
        else if (flashingTime < 250) renderer.material.color = Color.yellow;
        else renderer.material.color = Color.red;
    }

    /// <summary>
    /// 危険ラインをブロックが通過したとき、危険状態にする
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //ブロックがすり抜けた時のみ、ステータス変更
        if (other.gameObject.tag == "AliveBlock" && GameManager.gameStatus != GameStatus.GameOver)
            GameManager.gameStatus = GameStatus.InGameWarning;
        
    }
}
