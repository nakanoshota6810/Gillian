using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコアUIを管理
/// </summary>
public class ResultScoreUI : MonoBehaviour
{
    //破壊したブロック数を表示するテキストを格納
    [SerializeField] Text blockBreakCountText;

    //最大コンボ数を表示させるテキストを格納
    [SerializeField] Text maxComboCountText;

    //スコアを表示するテキストを格納
    [SerializeField] Text scoreText;
  
    // Start is called before the first frame update
    void Start()
    {
        //各スコアをテキストに記載
        blockBreakCountText.text    = "破壊したブロック数 : "    + Score.blockBreakCount;
        maxComboCountText.text      = "最大コンボ数 : "          + Score.maxComboCount;
        scoreText.text              = "スコア : "                + Score.score;
    }
}
