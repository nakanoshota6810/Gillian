using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// StageFunctionBase�̃I�[�o�[���C�h��
/// �Q�[���J�n���̃u���b�N�Q�̔z�u�@�\
/// </summary>
public class StageFunctionSetStartBlocks : StageFunctionBase
{
    // Start is called before the first frame update
    public override void ItStart()
    {
        //��
        int columnCount = 10;

        //X���̒��S��0�̂��߁A�}�C�i�X�����ɑS�̂��ړ�������l
        int halfValue = 45;

        //�Q�[�����[�h�����C�h���[�h�̎��̂݁A������ύX����
        if (GameManager.gameMode == GameMode.WideMode)
        {
            columnCount = 18;
            halfValue = 85;
        }

        //�Q�[���J�n���A�܂Ƃ܂����u���b�N�Q�𐶐�
        for (int column = 0; column < columnCount; column++)
        {
            for (int line = 0; line < 5; line++)
            {
                //�u���b�N���v�Z�����ʒu�ɏo��������
                StageBlockManager.GetSleepBlock().BlockInstantiate(new Vector3(column * 10 - halfValue, line * 12 + 150, 0));
            }

            //�񂲂Ƃ̃u���b�N�̐��������i�[
            StageBlockManager.columnBlockCount.Add(5);
        }
    }

    public override void ItUpdate() {}
}
