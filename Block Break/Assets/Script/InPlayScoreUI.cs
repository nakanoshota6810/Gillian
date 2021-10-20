using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InPlayScoreUI : MonoBehaviour
{
    //ゲーム画面に出すコンボテキストを格納
    [SerializeField] private Text inPlayComboCountUIText;

    private void Start()
    {
        //コンボカウントをテキストに記載
        inPlayComboCountUIText.text = Score.comboCount + " コンボ";
    }

    // Update is called once per frame
    void Update()
    {
        //コンボカウントをテキストに記載
        inPlayComboCountUIText.text = Score.comboCount + " コンボ";
    }
}
