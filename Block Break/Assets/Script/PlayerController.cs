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

    private TimeCountChack colorChangeTime;

    public int playerColor { get; private set; }

    private new Renderer renderer;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
        playerColor = 0;
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
        if (GameManager.statusNo == MainGameStatus.InGameWarning) 
            this.gameObject.SetActive(false);


        if (GameManager.gameMode == GameMode.TimeColorMode)
        {
            if (colorChangeTime == null)
            {
                colorChangeTime = new TimeCountChack(10);
                ChacgePlayerColor();
            }

            if (colorChangeTime.ChackTime())
            {

                playerColor = Random.Range(1, 99);
                playerColor = playerColor % 3;

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
        }
    }
}
