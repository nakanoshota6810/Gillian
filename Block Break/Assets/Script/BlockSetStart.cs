using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム開始時のブロック群の配置機能
/// </summary>
public class BlockSetStart : MonoBehaviour
{
    //スポーンするブロックを格納する
    [SerializeField] private GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム開始時、まとまったブロック群を生成する
        for(int column = 0; column < 10; column++)
        {
            for(int line = 0; line < 5; line++)
            {
                //ブロックの生成
                GameObject obj = Instantiate(block);

                //生成したブロックの位置を設定
                obj.transform.position = new Vector3(column * 10 - 45, line * 10 + 110, 0);

            }

            //列ごとのブロックの生存数を格納
            BlockManager.columnBlockCount.Add(5);
        }
    }
}
