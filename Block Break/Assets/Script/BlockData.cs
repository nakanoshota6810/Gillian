using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 各ブロックの機能
/// </summary>
public class BlockData : MonoBehaviour
{
    //ブロックの鈍足時の空気抵抗値
    [SerializeField] private int blockDrag;

    //ブロックの色
    private int blockColor;

    //ブロックのスポーン状態の維持時間
    private int blockSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        blockColor = 0;
        blockSpawnTime = 3000;
        RandomBlockColor();
    }

    // Update is called once per frame
    void Update()
    {
        //ブロックが落下してから一定時間経過したら、落下速度を鈍足にする
        if (blockSpawnTime <= 0 && this.tag == "SpawnBlock")
        {
            //タグとレイヤーを鈍足用のものに変更
            this.tag = "AliveBlock";
            this.gameObject.layer = 6;

            //落下時に受ける空気抵抗の値を上昇させる
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.drag = blockDrag;
        }
        else if (this.tag == "SpawnBlock")
        {
            blockSpawnTime--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //ブロックがSpawnLineを超えたら、落下速度を鈍足にする
        if (collision.gameObject.tag=="SpownLine" && this.tag == "SpawnBlock")
        {
            //タグとレイヤーを鈍足用のものに変更
            this.tag = "AliveBlock";
            this.gameObject.layer = 6;

            //落下時に受ける空気抵抗の値を上昇させる
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.drag = blockDrag;
        }
    }

    /// <summary>
    /// ブロックの色を乱数で決定する
    /// </summary>
    private void RandomBlockColor()
    {
        //ブロックの色番号を乱数で指定
        blockColor = Random.Range(1, 4);

        switch (blockColor)
        {
            case 1:
                //ブロックの色を緑に変える
                GetComponent<Renderer>().material.color = Color.green;
                break;

            case 2:
                //ブロックの色を赤に変える
                GetComponent<Renderer>().material.color = Color.red;
                break;

            case 3:
                //ブロックの色を青に変える
                GetComponent<Renderer>().material.color = Color.blue;
                break;
        }

    }
}
