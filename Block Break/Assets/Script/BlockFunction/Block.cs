using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private BlockData       blockData;
    private BlockController blockController;



    [SerializeField] private GameObject effectObject;

    // Start is called before the first frame update
    void Start()
    {
        blockData = new BlockData();

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Renderer renderer = GetComponent<Renderer>();
        blockController = new BlockController(rigidbody, renderer,blockData);
        blockController.ItStart();
    }

    // Update is called once per frame
    void Update()
    {
        blockController.ItUpdate();

        if (blockData.blockStatus == BlockStatus.SuperBreak)
            BlockSuperBreak();

        if (!blockData.blockActive) Destroy(this.gameObject);

        this.tag = blockData.blockTag;
        this.gameObject.layer = blockData.blockLayerNo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        blockController.ItCollisionEnter(collision);
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
            obj.GetComponent<EffectController>().SetVector(effectVector[i], transform.position);

        }

        blockData.blockStatus = BlockStatus.None;
        blockData.blockActive = false;
    }
}
