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

    //プレイヤーの情報を格納する
    [SerializeField] private PlayerController playerController;

    //玉の色を管理する変数を宣言
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
        ballColor = ColorPallet.Red;
        renderer.material.color = Color.red;
    }


    private void Update()
    {
        //左クリックごとに玉の色を変える
        if (Input.GetMouseButtonDown(0))
        {
            //ゲーム開始時に、弾に動力を与える処理
            ClickGameStart();

            //クリック時に玉の色を変える処理
            ClickChangeBallColor();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //玉が落下した判定処理
        UnderFall();

        //玉の移動処理
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ゲームモードがタイムカラーモードの時のみ、プレイヤーに接触することで、玉の色がプレイヤーの色に変化する
        if (collision.gameObject.tag == "Ball" && GameManager.gameMode == GameMode.TimeColorMode)
        {
            ballColor = playerController.playerColor;

            //玉の色を変更
            ChangeBlockColor();
        }
    }

    /// <summary>
    /// ゲーム開始を行うと同時に、玉を打ち上げる処理
    /// </summary>
    void ClickGameStart()
    {
        //最初のワンクリックでゲームを開始
        if (GameManager.gameStatus == GameStatus.Ready)
        {
            //最初に右斜め上へ移動速度分の動力を計算
            Vector3 force = new Vector3(1.0f, 1.0f, 0) * ballSpeed * 100;
            //玉に力を加える
            rigidbody.AddForce(force);

            //ゲームステータスをインゲームに変更
            GameManager.gameStatus = GameStatus.InGameNormal;
            return;
        }
    }

    /// <summary>
    /// 左クリック時、玉の色を変更する処理
    /// </summary>
    void ClickChangeBallColor()
    {
        //タイムカラーモード以外で処理を行う
        if (GameManager.gameMode != GameMode.TimeColorMode)
        {
            //玉の色番号を変更(赤→緑→青→赤)
            int colorNo = (int)ballColor - 1;
            colorNo++;
            ballColor = (ColorPallet)(colorNo % 3 + 1);

            //玉の色を変更
            ChangeBlockColor();
        }
    }

    /// <summary>
    /// 玉が画面外まで落下した場合の処理
    /// </summary>
    void UnderFall()
    {
        //玉が画面外の下まで落ちた時、ゲームオーバー
        if (transform.position.y < -45)
        {
            //ゲームステータスをゲームオーバーに変更
            GameManager.gameStatus = GameStatus.GameOver;

            //玉を消滅させる
            this.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 玉の移動を管理する処理
    /// </summary>
    void Move()
    {
        //玉の移動速度ごとの、速度基準値を設定
        float ballVelocityBase = ballSpeed * 40.0f;

        //判定用に、玉のVelocityのX軸とY軸の移動速度の、正の値を計算
        Vector3 vec = rigidbody.velocity;
        float chackX = vec.x > 0 ? vec.x : vec.x * (-1);
        float chackY = vec.y > 0 ? vec.y : vec.y * (-1);

        //玉の移動速度が基準通りでないなら、修正を加える
        if ((chackX + chackY < ballVelocityBase || chackX + chackY > ballVelocityBase + 1.0f) && chackX + chackY > 0)
        {
            //X軸とY軸の移動速度の比率を計算
            float percent = chackX + chackY;
            float perX = vec.x / percent;
            float perY = vec.y / percent;

            //速度基準値にそれぞれ比率をかけ、移動速度を算出
            vec.x = ballVelocityBase * perX;
            vec.y = ballVelocityBase * perY;

            //判定用に再度、X軸とY軸の移動速度の正の値を計算
            chackX = vec.x > 0 ? vec.x : vec.x * (-1);
            chackY = vec.y > 0 ? vec.y : vec.y * (-1);

            //なるべく、真横と真縦に移動しないように処理
            if ((chackX > chackY ? chackX - chackY : chackY - chackX) > 30 * ballSpeed)
            {
                //向きを斜めに傾ける
                vec.x += 5 * ballSpeed;
                vec.y -= 5 * ballSpeed;
            }

            //計算後の値を、Velocityに渡す
            rigidbody.velocity = vec;
        }
    }


    /// <summary>
    /// 玉の色を変更する
    /// </summary>
    private void ChangeBlockColor()
    {
        switch (ballColor)
        {
            case ColorPallet.Red:
                renderer.material.color = Color.red;
                break;

            case ColorPallet.Green:
                renderer.material.color = Color.green;
                break;

            case ColorPallet.Blue:
                renderer.material.color = Color.blue;
                break;
        }
    }
}
