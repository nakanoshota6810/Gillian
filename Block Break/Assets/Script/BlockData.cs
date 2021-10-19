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

    //生成する衝撃波用(連鎖用)エフェクト設定
    [SerializeField] private GameObject blockEffect;

    //ブロックのスポーン状態の維持時間
    private int blockSpawnTime;

    //ブロックの色
    private int blockColor;

    //ブロックのRigidboryを格納する変数を宣言
    private new Rigidbody rigidbody;

    //ブロックのRendererを格納する変数を宣言
    private new Renderer renderer;

    //衝撃波用に上下左右のベクトル方向を格納する変数を宣言
    private Vector3[] effectVector;


    // Start is called before the first frame update
    void Start()
    {
        //各コンポーネントを取得
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        //ブロックの色を乱数で変更する
        blockColor = Random.Range(0, 3);
        ChangeBlockColor();

        //鈍化までの値を初期化
        blockSpawnTime = 3000;

        //上下左右のベクトルを作成
        effectVector = new Vector3[4];
        effectVector[0] = new Vector3(1, 0, 0);
        effectVector[1] = new Vector3(0, 1, 0);
        effectVector[2] = new Vector3(-1, 0, 0); 
        effectVector[3] = new Vector3(0, -1, 0);
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
            rigidbody.drag = blockDrag;
        }
        //SpawnBlockタグのみ、カウントダウンを進める
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
            rigidbody.drag = blockDrag;
        }

        //衝撃波に接触時、ブロックは消滅
        if (collision.gameObject.tag == "Effect")
        {
            Destroy(this.gameObject);
        }

        //玉と接触時のみ処理に入る
        if (collision.gameObject.tag == "Player")
        {
            //玉とブロックの色が同じであれば、ブロックは消滅
            BallController ball = collision.gameObject.GetComponent<BallController>();
            if (ball.ballColor == blockColor)
                Destroy(this.gameObject);
            else
            {
                if (blockColor < 3)
                {
                    blockColor += ball.ballColor + 2;
                    ChangeBlockColor();
                    return;
                }

                if (blockColor + ball.ballColor + 1 == 6)
                {
                    WhiteBlockBreak();
                    Destroy(this.gameObject);
                }
            }
        }
    }

    /// <summary>
    /// ブロックの色を乱数で決定する
    /// </summary>
    private void ChangeBlockColor()
    {
        switch (blockColor)
        {
            case 0:
                //ブロックの色を赤に変更
                renderer.material.color = Color.red;
                break;

            case 1:
                //ブロックの色を緑に変更
                renderer.material.color = Color.green;
                break;

            case 2:
                //ブロックの色を青に変更
                renderer.material.color = Color.blue;
                break;

            case 3:
                //ブロックの色をイエローに変更
                renderer.material.color = Color.yellow;
                break;

            case 4:
                //ブロックの色をマゼンタに変更
                renderer.material.color = Color.magenta;
                break;

            case 5://ブロックの色をシアンに変更
                renderer.material.color = Color.cyan;
                break;

        }
    }

    /// <summary>
    /// 白いブロックが破壊されたとき、上左右一直線へ衝撃波を走らせる(連鎖処理)
    /// </summary>
    private void WhiteBlockBreak()
    {
        //三方向にそれぞれ衝撃波を生成
        for (int i = 0; i < 3; i++)
        {
            //衝撃波生成
            GameObject obj = Instantiate(blockEffect);

            //走らせる向きと破壊されたブロックの位置を渡す
            obj.GetComponent<EffectController>().SetVector(effectVector[i], transform.position);

        }
    }
}
