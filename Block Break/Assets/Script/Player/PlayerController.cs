using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーコントロール機能
/// </summary>
public class PlayerController : MonoBehaviour
{
    //プレイヤーの移動速度を設定
    [SerializeField] private float moveSpeed = 1.0f;

    //プレイヤーの色が切り替わる時間を管理するインスタンス
    private Timer colorChangeTime;

    //プレイヤーの色情報を格納
    public ColorPallet playerColor { get; private set; }

    //Rendererを格納するインスタンスを宣言
    private new Renderer renderer;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのポジションを格納
        Vector3 vec = transform.position;

        //キー入力で左右に移動する(-40～40の範囲)
        //右に移動
        if (Input.GetKey(KeyCode.D) && transform.position.x < (GameManager.gameMode == GameMode.WideMode ? 70 : 40))
            transform.position += new Vector3(1.0f, 0, 0) * moveSpeed * Time.deltaTime * 100;
        //左に移動
        else if (Input.GetKey(KeyCode.A) && transform.position.x > (GameManager.gameMode == GameMode.WideMode ? -70 : -40))
            transform.position += new Vector3(-1.0f, 0, 0) * moveSpeed * Time.deltaTime * 100;


        //Waringラインを超えたら、プレイヤーは消滅
        if (GameManager.gameStatus == GameStatus.InGameWarning) 
            this.gameObject.SetActive(false);


        //タイムカラーゲームモードの時に処理が行われる
        if (GameManager.gameMode == GameMode.TimeColorMode)
        {
            //タイマーが動いていない場合は、動かす。
            if (colorChangeTime == null)
            {
                colorChangeTime = new Timer(6);
                playerColor = ColorPallet.Red;
                ChacgePlayerColor();
            }

            //一定カウントごとにプレイヤーの色を変更する
            if (colorChangeTime.ChackTime())
            {
                int color = (int)playerColor - 1;
                color++;
                playerColor = (ColorPallet)(color % 3) + 1;
                ChacgePlayerColor();
            }
        }
    }


    /// <summary>
    /// プレイヤーの色を変更する
    /// </summary>
    private void ChacgePlayerColor()
    {
        switch (playerColor)
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
