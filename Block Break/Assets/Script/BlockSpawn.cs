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

    //スポーンしたブロックをインスペクターに直接移さないようにする親を格納する
    [SerializeField] private Transform blockParent;

    //スポーン感覚を計るための時間を格納する変数を宣言
    private int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 300;
    }

    // Update is called once per frame
    void Update()
    {

        //開始前にブロックを生成しないようにする
        if (GameManager.statusNo == MainGameStatus.GameOver || GameManager.statusNo == MainGameStatus.Title|| GameManager.statusNo == MainGameStatus.Ready) return;

        timeCount--;

        //一定ごとにブロックを生成
        if (timeCount <= 0)
        {
            //出現するブロックの列番号を乱数で取得
            int columnNo = Random.Range(0, 10);

            //列番号のブロック数が一定以上だと、その列にブロックを生成しない
            if (BlockManager.columnBlockCount[columnNo] > 10) return;
            
            //列番号のブロック数を一つ加算
            BlockManager.columnBlockCount[columnNo] += 1;

            //値ごとに出現位置を調整
            int randPositionX = columnNo * 10 - 45;

            //ブロックの生成
            GameObject obj = Instantiate(block, blockParent);

            //生成したブロックの位置を設定
            obj.transform.position = new Vector3(randPositionX, 200, 0);

            //タイムカウントを再セット
            timeCount = 300;
        }
    }
}
