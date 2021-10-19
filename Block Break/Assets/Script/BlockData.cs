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

    [SerializeField] private GameObject blockEffect;

    //ブロックのスポーン状態の維持時間
    private int blockSpawnTime;

    //ブロックの色
    private int blockColor;

    //ブロックのRigidboryを格納する変数を宣言
    private new Rigidbody rigidbody;

    //ブロックのRendererを格納する変数を宣言
    private new Renderer renderer;

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

        if (collision.gameObject.tag == "Effect")
        {
            Destroy(this.gameObject);
        }

        //玉と接触時のみ処理に入る
        if (collision.gameObject.tag == "Player")
        {
            //玉とブロックの色が同じであれば、ブロックは消滅する
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
                    WhiteBlockBreak(transform.position);
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
                //ブロックの色を赤に変える
                renderer.material.color = Color.red;
                break;

            case 1:
                //ブロックの色を緑に変える
                renderer.material.color = Color.green;
                break;

            case 2:
                //ブロックの色を青に変える
                renderer.material.color = Color.blue;
                break;

            case 3:
                //ブロックの色をイエローに変える
                renderer.material.color = Color.yellow;
                break;

            case 4:
                //ブロックの色をマゼンタに変える
                renderer.material.color = Color.magenta;
                break;

            case 5://ブロックの色をシアンに変える
                renderer.material.color = Color.cyan;
                break;

        }
    }

    private void WhiteBlockBreak(Vector3 vec)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(blockEffect);

            obj.GetComponent<EffectController>().SetVector(effectVector[i], transform.position);

        }
    }
}
