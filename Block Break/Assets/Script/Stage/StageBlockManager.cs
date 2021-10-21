using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロック群の管理機能
/// </summary>
public class StageBlockManager : MonoBehaviour
{
    //スポーンするブロックを格納する
    [SerializeField] private GameObject block = null;

    //生成する大量のブロックをインスペクターに移さないようにする、ブロック群の親
    [SerializeField] private Transform blockParent;

    static private GameObject staticBlock = null;

    static private Transform staticBlockParent = null;

    static public bool blockAlive = false;

    //ブロック群を格納するリスト変数を宣言
    static public List<GameObject> blockList = new List<GameObject>();

    //列ごとのブロック生存数を格納するリスト変数を宣言
    static public List<int> columnBlockCount = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject block in blockList)
        {
            Destroy(block);
        }
        blockList.Clear();

        staticBlock = block;
        staticBlockParent= blockParent;

        GameObject obj = Instantiate(staticBlock, staticBlockParent);
        blockList.Add(obj);
    }

    static public Block GetSleepBlock()
    {
        Block itBlock = null;

        foreach (GameObject block in blockList)
        {
            itBlock = block.GetComponent<Block>();
            if (!itBlock.GetBlockActive())
                return itBlock;
        }

        GameObject obj = Instantiate(staticBlock, staticBlockParent);

        blockList.Add(obj);

        return itBlock;
    }
}
