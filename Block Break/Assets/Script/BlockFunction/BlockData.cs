/// <summary>
/// 各ブロックの機能
/// </summary>
public class BlockData 
{
    //ブロックの色
    public ColorPallet blockColor { get; set; }

    //ブロックのステータス
    public BlockStatus blockStatus { get; set; }

    //ブロックの生存状態
    public bool blockActive { get; set; }

    //ブロックのタグ
    public string blockTag { get; set; }

    //ブロックのレイヤー
    public int layerNo { get; set; }


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
