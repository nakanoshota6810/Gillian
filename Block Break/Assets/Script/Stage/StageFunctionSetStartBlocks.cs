using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム開始時のブロック群の配置機能
/// </summary>
public class StageFunctionSetStartBlocks : StageFunctionBase
{
    // Start is called before the first frame update
    public override void ItStart()
    {
        int columnCount = 10;
        int halfValue = 45;
        if (GameManager.gameMode == GameMode.WideMode)
        {
            columnCount = 18;
            halfValue = 85;
        }

        //ゲーム開始時、まとまったブロック群を生成
        for (int column = 0; column < columnCount; column++)
        {
            for (int line = 0; line < 5; line++)
            {
                //ブロックを計算した位置に出現させる
                StageBlockManager.GetSleepBlock().BlockInstantiate(new Vector3(column * 10 - halfValue, line * 12 + 150, 0));
            }

            //列ごとのブロックの生存数を格納
            StageBlockManager.columnBlockCount.Add(5);
        }
    }

    public override void ItUpdate()
    {

    }
}
