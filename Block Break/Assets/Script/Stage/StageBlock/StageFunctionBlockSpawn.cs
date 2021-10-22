using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// StageFunctionBase�̃I�[�o�[���C�h��
/// �u���b�N�̃X�|�[���@�\
/// </summary>
public class StageFunctionBlockSpawn : StageFunctionBase
{
    //�X�|�[�����o���v�邽�߂̎��Ԃ��i�[����ϐ���錾
    private Timer timeCountChack;

    // Start is called before the first frame update
    public override void ItStart()
    {
        //�^�C�}�[�̃Z�b�g
        timeCountChack = new Timer(5);
    }

    // Update is called once per frame
    public override void ItUpdate()
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

        //���J�E���g���Ƀu���b�N�𐶐�
        if (timeCountChack.ChackTime())
        {
            //�o������u���b�N�̗�ԍ��𗐐��Ŏ擾
            int columnNo = Random.Range(0, columnCount);

            //��ԍ��̃u���b�N�������ȏゾ�ƁA���̗�Ƀu���b�N�𐶐����Ȃ�
            if (StageBlockManager.columnBlockCount[columnNo] > 10) return;

            //��ԍ��̃u���b�N��������Z
            StageBlockManager.columnBlockCount[columnNo] += 1;

            //�l���Ƃɏo���ʒu�𒲐�
            int randPositionX = columnNo * 10 - halfValue;

            //�u���b�N���v�Z�����ʒu�ɏo��������
            StageBlockManager.GetSleepBlock().BlockInstantiate(new Vector3(randPositionX, 200, 0));
        }
    }
}
