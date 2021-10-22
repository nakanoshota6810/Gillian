using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //ブロックのデータクラスのインスタンスを格納する変数を宣言
    private BlockData       blockData;

    //ブロックのコントロールクラスのインスタンスを格納する変数を宣言
    private BlockController blockController;

    //ブロックのスーパーブレイク時に流す衝撃波演出のオブジェクトを格納
    [SerializeField] private GameObject effectObject;

    private void Awake()
    {
        //ブロックデータクラスをインスタンス化
        blockData = new BlockData();

        //コンポーネントを読み込む
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Renderer renderer = GetComponent<Renderer>();

        //ブロックコントロールクラスのインスタンス化
        blockController = new BlockController(rigidbody, renderer, blockData);

        //ブロックのアクティブ化
        blockController.BlockInstantiate(); ;
    }

    // Update is called once per frame
    void Update()
    {
        //ブロックの挙動を更新
        blockController.ItUpdate();

        //ブロックのステータスが「SuperBreak」なら、処理を行う
        if (blockData.blockStatus == BlockStatus.SuperBreak)
            BlockSuperBreak();

        //ブロックデータがfalseなら、ブロック自体を非アクティブ状態にする
        if (!blockData.blockActive)
            this.gameObject.SetActive(false);
        
        //各タグとレイヤーを更新
        this.tag = blockData.blockTag;
        this.gameObject.layer = blockData.blockLayerNo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //当たり判定毎に処理を行う
        blockController.ItCollisionEnter(collision);
    }

    /// <summary>
    /// ブロックがアクティブ化したとき処理を行う
    /// </summary>
    /// <param アクティブ化させる位置情報="positionVector"></param>
    public void BlockInstantiate(Vector3 positionVector)
    {
        blockData.blockActive = true;
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = positionVector;
        blockController.BlockInstantiate();
    }

    /// <summary>
    /// ブロックのアクティブ状態を返す
    /// </summary>
    /// <returns></returns>
    public bool GetBlockActive()
    {
        return blockData.blockActive;
    }

    /// <summary>
    /// 混合色ブロックが破壊されたとき、上左右一直線へ衝撃波を走らせる(連鎖処理)
    /// </summary>
    private void BlockSuperBreak()
    {
        //衝撃波用に上下左右のベクトル方向を格納する変数を宣言
        Vector3[] effectVector;

        //上下左右のベクトルを作成
        effectVector = new Vector3[4];

        effectVector[0] = new Vector3(1, 0, 0);
        effectVector[1] = new Vector3(0, 1, 0);
        effectVector[2] = new Vector3(-1, 0, 0);
        effectVector[3] = new Vector3(0, -1, 0);

        //三方向にそれぞれ衝撃波を生成
        for (int i = 0; i < 3; i++)
        {
            //衝撃波生成
            GameObject obj = Instantiate(effectObject);

            //走らせる向きと破壊されたブロックの位置を渡す
            obj.GetComponent<EffectController>().SetVectors(effectVector[i], transform.position);

        }

        //ブロックデータのアクティブ情報をfalseにする
        blockData.blockActive = false; 
        blockData.blockStatus = BlockStatus.None;
    }
}
