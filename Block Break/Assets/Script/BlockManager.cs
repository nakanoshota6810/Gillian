using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロック群の管理機能
/// </summary>
public class BlockManager : MonoBehaviour
{
    //列ごとのブロック生存数を格納するリスト変数を宣言
    static public List<int> columnBlockCount;

    public int timeCount { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 1000;
        columnBlockCount = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (--timeCount <= 0)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int log = columnBlockCount[i];
        //        Debug.Log(log);
        //    }

        //    timeCount = 1000;
        //}
    }
}
