using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックのスポーン機能
/// </summary>
public class BlockSpawn : MonoBehaviour
{
    //スポーンするブロックを格納する
    [SerializeField] private GameObject block;

    //スポーン感覚を計るための時間を格納する変数を宣言
    private int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount--;

        //一定ごとにブロックが生成される
        if (timeCount <= 0)
        {
            //出現するブロックの列番号を乱数で取得
            int columnNo = Random.Range(0, 10);

            //列番号のブロック数が一定以上だと、その列にブロックを生成しない
            if (BlockManager.columnBlockCount[columnNo] > 10)return;
            
            //列番号のブロック数を一つ加算
            BlockManager.columnBlockCount[columnNo] += 1;

            //値ごとに出現位置を調整
            int randPositionX = columnNo * 10 - 45;

            //ブロックの生成
            GameObject obj = Instantiate(block);

            //生成したブロックの位置を設定
            obj.transform.position = new Vector3(randPositionX, 90, 0);

            //タイムカウントを再セット
            timeCount = 1000;
        }
    }
}
