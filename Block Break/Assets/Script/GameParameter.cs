using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内のパラメータを全部記載
/// </summary>
class GameParameter :MonoBehaviour
{
    //ゲームオーバーラインの高さの初期値を設定
    [SerializeField] private float lineUnderPositionY;
    static public float gameOverLineUnderPositionY;


    public GameParameter()
    {
        //ゲームオーバーラインの高さの初期値を静的関数に移す
        gameOverLineUnderPositionY = lineUnderPositionY;






    }


}
