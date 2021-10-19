using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロック群の管理機能
/// </summary>
public class BlockManager : MonoBehaviour
{
    //列ごとのブロック生存数を格納するリスト変数を宣言
    static public List<int> columnBlockCount = new List<int>();

    static GameObject blockEffect;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void WhiteBlockBreak(Vector3 vec)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(blockEffect);

            
        }
    }

}


