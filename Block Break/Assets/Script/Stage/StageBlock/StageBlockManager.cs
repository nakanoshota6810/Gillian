using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロック群の管理機能
/// 静的処理で管理を行う
/// </summary>
public class StageBlockManager : MonoBehaviour
{
    //スポーンするブロックを格納する
    [SerializeField] private GameObject block = null;

    //生成する大量のブロックをインスペクターに移さないようにする、ブロック群の親
    [SerializeField] private Transform blockParent;

    //静的関数用のスポーンするブロックを格納する変数
    static private GameObject staticBlock = null;

    //静的関数用のブロック群の親を格納する変数
    static private Transform staticBlockParent = null;

    //ブロック群を格納する静的リスト変数を宣言
    static public List<GameObject> blockList = new List<GameObject>();

    //列ごとのブロック生存数を格納する静的リスト変数を宣言
    static public List<int> columnBlockCount = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        ////最初にブロックリストを初期化する
        //foreach (GameObject block in blockList)
        //{
        //    Destroy(block);
        //}
        blockList.Clear();
        columnBlockCount.Clear();

        //静的変数に器を移す
        staticBlock = block;
        staticBlockParent = blockParent;

        ////最初に一つだけブロックを生成し、リストに追加する
        //GameObject obj = Instantiate(staticBlock, staticBlockParent);
        //blockList.Add(obj);
    }

    /// <summary>
    /// 使用されていないブロックを返す
    /// </summary>
    /// <returns></returns>
    static public Block GetSleepBlock()
    {
        Block itBlock = null;

        //非アクティブ状態のブロックを、リストから見つけ次第返す
        foreach (GameObject block in blockList)
        {
            itBlock = block.GetComponent<Block>();
            if (!itBlock.GetBlockActive())
                return itBlock;
        }

        //非アクティブ状態がリストに一つもない場合、新たにブロックを生成する
        GameObject obj = Instantiate(staticBlock, staticBlockParent);
        itBlock = obj.GetComponent<Block>();

        blockList.Add(obj);

        //生成したブロックを返す
        return itBlock;
    }
}
