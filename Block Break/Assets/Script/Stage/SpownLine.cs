using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックの落下速度を鈍化する基準機能
/// ブロック生成時にブロックは素早く落下し、このライン通過で鈍化(ブロックステータスの変更)させる
/// </summary>
public class SpownLine : MonoBehaviour
{
    //ブロックが鈍足化するラインの初期値を格納
    [SerializeField] private float lineStratPositionY;

    //ブロックが鈍足化するラインの下限値を格納
    [SerializeField] private float lineUnderPositionY;

    // Start is called before the first frame update
    void Start()
    {
        //ラインの高さを更新
        PositionUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        //徐々に下限値までラインを下げる
        if (lineStratPositionY > lineUnderPositionY) lineStratPositionY -= 0.01f;

        //ラインの高さを更新
        PositionUpdate();
    }

    /// <summary>
    /// スポーンラインの高さを更新する
    /// </summary>
    void PositionUpdate()
    {
        Vector3 vec = transform.position;
        vec.y = lineStratPositionY;
        transform.position = vec;
    }
}
