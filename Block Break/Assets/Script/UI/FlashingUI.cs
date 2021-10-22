using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UIの点滅を管理
/// </summary>
public class FlashingUI : MonoBehaviour
{
    //点滅させるテキストを設定
    [SerializeField] private Text gameStartConditionText = null;

    //点滅の基準となるタイムカウントを格納する変数を宣言
    private int flashingTime;

    // Start is called before the first frame update
    void Start()
    {
        //タイムカウントの初期化
        flashingTime = 300;
    }

    // Update is called once per frame
    void Update()
    {
        flashingTime--;

        //タイムカウントごとに、テキストを点滅させる
        if (flashingTime <= 0) flashingTime = 300;
        else if (flashingTime < 70) gameStartConditionText.gameObject.SetActive(false);
        else gameStartConditionText.gameObject.SetActive(true);
    }
}
