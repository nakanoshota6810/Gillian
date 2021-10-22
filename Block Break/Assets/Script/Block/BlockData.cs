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
    public int blockLayerNo { get; set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BlockData()
    {
        //初期化
        blockColor = ColorPallet.Nome;
        blockStatus = BlockStatus.Spawn;
        blockActive = false;
        blockTag = "SpawnBlock";
        blockLayerNo = 7;
    }
}
