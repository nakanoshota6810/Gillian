using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //玉の速さを設定
    [SerializeField] private float ballSpeed = 1.0f;

    //玉の色を番号で格納する変数
    public int ballColor { get; private set; }

    //玉のRigidboryを格納する変数を宣言
    private new Rigidbody rigidbody;

    //玉のRendererを格納する変数を宣言
    private new Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        //最初に右斜め上へ移動速度分の動力を計算
        Vector3 force = new Vector3(1.0f, 1.0f, 0) * ballSpeed * 100;

        //各コンポーネントを取得
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        //玉に力を加える
        rigidbody.AddForce(force);

        //玉の色の初期設定(赤)
        ballColor = 0;
        renderer.material.color = Color.red;

    }

    private void Update()
    {
        //左クリックごとに玉の色を変える
        if (Input.GetMouseButtonDown(0))
        {
            ballColor++;
            ballColor = ballColor % 3;

            //番号ごとに玉の色を変更する
            RandomBlockColor();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //玉の移動速度ごとの、速度基準を設定
        float ballVelocityBase = ballSpeed * 40.0f;

        //玉のVelocityのX軸とY軸の移動速度を、すべて正の値にする
        Vector3 vec = rigidbody.velocity;
        float chackX = vec.x > 0 ? vec.x : vec.x * (-1);
        float chackY = vec.y > 0 ? vec.y : vec.y * (-1);

        //玉の移動速度が基準を上回っているなら、修正を加える
        if ((chackX + chackY < ballVelocityBase || chackX + chackY > ballVelocityBase + 1.0f) && chackX + chackY > 0)
        {
            //X軸とY軸の移動速度の比率を計算
            float percent = chackX + chackY;
            float perX = vec.x / percent;
            float perY = vec.y / percent;

            //基準値にそれぞれ比率をかけ、移動速度を算出
            vec.x = ballVelocityBase * perX;
            vec.y = ballVelocityBase * perY;

            chackX = vec.x > 0 ? vec.x : vec.x * (-1);
            chackY = vec.y > 0 ? vec.y : vec.y * (-1);



            //真横と真縦に移動しないように処理
            if ((chackX > chackY ? chackX - chackY : chackY - chackX) > 30 * ballSpeed)
            {
                vec.x += 4 * ballSpeed;
                vec.y -= 4 * ballSpeed;
            }

            //計算後の値を、Velocityに渡す
            rigidbody.velocity = vec;
        }

    }

    /// <summary>
    /// 玉の色を変更する
    /// </summary>
    private void RandomBlockColor()
    {
        switch (ballColor)
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
        }
    }
}
