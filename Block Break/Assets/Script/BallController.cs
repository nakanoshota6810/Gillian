using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玉コントロール機能
/// </summary>
public class BallController : MonoBehaviour
{
    //玉の速さを設定
    [SerializeField] private float ballSpeed = 1.0f;

    [SerializeField] private PlayerController playerController;

    //玉の色を番号で格納する変数
    public ColorPallet ballColor { get; private set; }

    //玉のRigidboryを格納する変数を宣言
    private new Rigidbody rigidbody;

    //玉のRendererを格納する変数を宣言
    private new Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        //各コンポーネントを取得
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        //玉の色の初期設定(赤)
        ballColor = 0;
        renderer.material.color = Color.red;
    }

    private void Update()
    {
        //玉が画面外の下まで落ちた時、ゲームオーバー
        if(transform.position.y < -45)
        {
            //ゲームステータスをゲームオーバーに変更
            GameManager.statusNo = MainGameStatus.GameOver;

            //玉を消滅させる
            this.gameObject.SetActive(false);
        }

        //左クリックごとに玉の色を変える
        if (Input.GetMouseButtonDown(0))
        {
            //最初のワンクリックでゲームを開始
            if (GameManager.statusNo == MainGameStatus.Ready)
            {
                //最初に右斜め上へ移動速度分の動力を計算
                Vector3 force = new Vector3(1.0f, 1.0f, 0) * ballSpeed * 100;
                //玉に力を加える
                rigidbody.AddForce(force);

                //ゲームステータスをインゲームに変更
                GameManager.statusNo = MainGameStatus.InGameNormal;
                return;
            }

            if (GameManager.gameMode != GameMode.TimeColorMode)
            {
                //玉の色番号を変更(赤→緑→青→赤)
                int colorNo = (int)ballColor - 1;
                colorNo++;
                ballColor = (ColorPallet)(colorNo % 3 + 1);

                //番号ごとに玉の色を変更
                RandomBlockColor();
            }
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

            //なるべく、真横と真縦に移動しないように処理
            if ((chackX > chackY ? chackX - chackY : chackY - chackX) > 30 * ballSpeed)
            {
                vec.x += 5 * ballSpeed;
                vec.y -= 5 * ballSpeed;
            }

            //計算後の値を、Velocityに渡す
            rigidbody.velocity = vec;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"&&GameManager.gameMode==GameMode.TimeColorMode)
        {
            ballColor = (ColorPallet)(playerController.playerColor+1);
            RandomBlockColor();
        }
    }

    /// <summary>
    /// 玉の色を変更する
    /// </summary>
    private void RandomBlockColor()
    {
        switch (ballColor)
        {
            case ColorPallet.Red:
                //ブロックの色を赤に変更
                renderer.material.color = Color.red;
                break;

            case ColorPallet.Green:
                //ブロックの色を緑に変更
                renderer.material.color = Color.green;
                break;

            case ColorPallet.Blue:
                //ブロックの色を青に変更
                renderer.material.color = Color.blue;
                break;
        }
    }
}
