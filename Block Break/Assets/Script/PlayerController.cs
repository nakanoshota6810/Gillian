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

    //プレイヤーが放つ花火オブジェクトを設定
    [SerializeField] private GameObject fireworkObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのポジションを格納
        Vector3 vec = transform.position;

        //キー入力で左右に移動する(-50～50の範囲)
        //右に移動
        if (Input.GetKey(KeyCode.D) && transform.position.x < 50)
        {
            transform.position += new Vector3(1.0f, 0, 0) * moveSpeed * Time.deltaTime * 100;
        }
        //左に移動
        else if (Input.GetKey(KeyCode.A) && transform.position.x > -50)
        {
            transform.position += new Vector3(-1.0f, 0, 0) * moveSpeed * Time.deltaTime * 100;
        }

        //マウスの左クリックで花火を放つ
        if (Input.GetMouseButtonDown(0))
        {
            //花火の生成
            GameObject obj = Instantiate(fireworkObject);

            //花火の位置をプレイヤーの位置にする
            obj.transform.position = transform.position;
        }
    }
}
