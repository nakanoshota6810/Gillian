using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム開始時のブロック群の配置機能
/// </summary>
public class BlockSetStart : MonoBehaviour
{
    //スポーンするブロックを格納する
    [SerializeField] private Block block;

    //生成する大量のブロックをインスペクターに移さないようにする、ブロック群の親
    [SerializeField] private Transform blockParent;

    private bool oneCreateFlag;

    // Start is called before the first frame update
    void Start()
    {
        oneCreateFlag = false;
    }

    private void Update()
    {

        //ゲーム開始前に一度だけまとまったブロック群を生成
        if (!oneCreateFlag && GameManager.statusNo == MainGameStatus.Ready)
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
                    //ブロックの生成
                    GameObject obj = Instantiate(block.gameObject, blockParent);

                    //生成したブロックの位置を設定
                    obj.transform.position = new Vector3(column * 10 - halfValue, line * 12 + 150, 0);

                }

                //列ごとのブロックの生存数を格納
                BlockManager.columnBlockCount.Add(5);

                oneCreateFlag = true;
            }
        }
    }
}
