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
    public int layerNo { get; set; }


    /// <summary>
    /// �����u���b�N���j�󂳂ꂽ�Ƃ��A�㍶�E�꒼���֏Ռ��g�𑖂点��(�A������)
    /// </summary>
    private void WhiteBlockBreak()
    {
        //�O�����ɂ��ꂼ��Ռ��g�𐶐�
        for (int i = 0; i < 3; i++)
        {
            //�Ռ��g����
            GameObject obj = Instantiate(blockEffect);

            //���点������Ɣj�󂳂ꂽ�u���b�N�̈ʒu��n��
            obj.GetComponent<EffectController>().SetVector(effectVector[i], transform.position);

        }
    }
}
