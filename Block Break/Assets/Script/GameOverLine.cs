using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームオーバーラインの機能
/// </summary>
public class GameOverLine : MonoBehaviour
{
    //ゲームオーバーラインの高さの初期値を設定
    [SerializeField] private float lineUnderPositionY;


    /// <summary>
    /// ゲームオーバーラインをブロックが通過したとき、ゲームオーバーにする
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //ブロックがすり抜けた時のみ、機能する
        if (other.gameObject.tag == "AliveBlock")
        {
            //現状はログのみ表示
            Debug.Log("GameOver");
        }
    }
}
