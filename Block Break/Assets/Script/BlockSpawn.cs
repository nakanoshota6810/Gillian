using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̃X�|�[���@�\
/// </summary>
public class BlockSpawn : MonoBehaviour
{
    //�X�|�[������u���b�N���i�[����
    [SerializeField] private GameObject block;

    //�X�|�[�����o���v�邽�߂̎��Ԃ��i�[����ϐ���錾
    private int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount--;

        //��育�ƂɃu���b�N�����������
        if (timeCount <= 0)
        {
            //�o������u���b�N�̗�ԍ��𗐐��Ŏ擾
            int columnNo = Random.Range(0, 10);

            //��ԍ��̃u���b�N�������ȏゾ�ƁA���̗�Ƀu���b�N�𐶐����Ȃ�
            if (BlockManager.columnBlockCount[columnNo] > 10)return;
            
            //��ԍ��̃u���b�N��������Z
            BlockManager.columnBlockCount[columnNo] += 1;

            //�l���Ƃɏo���ʒu�𒲐�
            int randPositionX = columnNo * 10 - 45;

            //�u���b�N�̐���
            GameObject obj = Instantiate(block);

            //���������u���b�N�̈ʒu��ݒ�
            obj.transform.position = new Vector3(randPositionX, 90, 0);

            //�^�C���J�E���g���ăZ�b�g
            timeCount = 1000;
        }
    }
}
