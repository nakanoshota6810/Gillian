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
        if (GameManager.statusNo == MainGameStatus.InGameWarning) flashingTime--;

        //タイムカウントごとに、テキストを点滅させる
        if (flashingTime <= 0) flashingTime = 500;
        else if (flashingTime < 250) renderer.material.color = Color.yellow;
        else renderer.material.color = Color.red;
    }

    /// <summary>
    /// ゲームオーバーラインをブロックが通過したとき、ゲームオーバーにする
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //ブロックがすり抜けた時のみ、機能する
        if (other.gameObject.tag == "AliveBlock" && GameManager.statusNo != MainGameStatus.GameOver)
            GameManager.statusNo = MainGameStatus.InGameWarning;
        
    }
}
