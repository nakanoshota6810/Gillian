using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックのスポーン機能
/// </summary>
public class StageFunctionBlockSpawn : StageFunctionBase
{
    //スポーン感覚を計るための時間を格納する変数を宣言
    private TimeCountChack timeCountChack;

    // Start is called before the first frame update
    public override void ItStart()
    {
        timeCountChack = new TimeCountChack(5);
    }

    // Update is called once per frame
    public override void ItUpdate()
    {
        //一定ごとにブロックを生成
        if (timeCountChack.ChackTime())
        {
            //出現するブロックの列番号を乱数で取得
            int columnNo = Random.Range(0, 10);

            //列番号のブロック数が一定以上だと、その列にブロックを生成しない
            if (StageBlockManager.columnBlockCount[columnNo] > 10) return;

            //列番号のブロック数を一つ加算
            StageBlockManager.columnBlockCount[columnNo] += 1;

            //値ごとに出現位置を調整
            int randPositionX = columnNo * 10 - 45;

            //ブロックを計算した位置に出現させる
            StageBlockManager.GetSleepBlock().BlockInstantiate(new Vector3(randPositionX, 200, 0));
        }
    }
}
