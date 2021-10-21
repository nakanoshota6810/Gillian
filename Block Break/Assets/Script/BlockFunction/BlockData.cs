/// <summary>
/// �e�u���b�N�̋@�\
/// </summary>
public class BlockData 
{
    //�u���b�N�̐F
    public ColorPallet blockColor { get; set; }

    //�u���b�N�̃X�e�[�^�X
    public BlockStatus blockStatus { get; set; }

    //�u���b�N�̐������
    public bool blockActive { get; set; }

    //�u���b�N�̃^�O
    public string blockTag { get; set; }

    //�u���b�N�̃��C���[
    public int blockLayerNo { get; set; }

    public BlockData()
    {
        Reset();
    }

    public void Reset()
    {
        blockColor  = ColorPallet.Nome;
        blockStatus = BlockStatus.None;
        blockActive = false;
        blockTag    = "SpawnBlock";
        blockLayerNo = 7;
    }

}
