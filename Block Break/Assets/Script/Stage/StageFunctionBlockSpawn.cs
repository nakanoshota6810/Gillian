using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̃X�|�[���@�\
/// </summary>
public class StageFunctionBlockSpawn : StageFunctionBase
{
    //�X�|�[�����o���v�邽�߂̎��Ԃ��i�[����ϐ���錾
    private TimeCountChack timeCountChack;

    // Start is called before the first frame update
    public override void ItStart()
    {
        timeCountChack = new TimeCountChack(5);
    }

    // Update is called once per frame
    public override void ItUpdate()
    {
        //��育�ƂɃu���b�N�𐶐�
        if (timeCountChack.ChackTime())
        {
            //�o������u���b�N�̗�ԍ��𗐐��Ŏ擾
            int columnNo = Random.Range(0, 10);

            //��ԍ��̃u���b�N�������ȏゾ�ƁA���̗�Ƀu���b�N�𐶐����Ȃ�
            if (StageBlockManager.columnBlockCount[columnNo] > 10) return;

            //��ԍ��̃u���b�N��������Z
            StageBlockManager.columnBlockCount[columnNo] += 1;

            //�l���Ƃɏo���ʒu�𒲐�
            int randPositionX = columnNo * 10 - 45;

            //�u���b�N���v�Z�����ʒu�ɏo��������
            StageBlockManager.GetSleepBlock().BlockInstantiate(new Vector3(randPositionX, 200, 0));
        }
    }
}
