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

    //�X�|�[�������u���b�N���C���X�y�N�^�[�ɒ��ڈڂ��Ȃ��悤�ɂ���e���i�[����
    [SerializeField] private Transform blockParent;

    //�X�|�[�����o���v�邽�߂̎��Ԃ��i�[����ϐ���錾
    private int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 300;
    }

    // Update is called once per frame
    void Update()
    {

        //�J�n�O�Ƀu���b�N�𐶐����Ȃ��悤�ɂ���
        if (GameManager.statusNo == MainGameStatus.GameOver || GameManager.statusNo == MainGameStatus.Title|| GameManager.statusNo == MainGameStatus.Ready) return;

        timeCount--;

        //��育�ƂɃu���b�N�𐶐�
        if (timeCount <= 0)
        {
            //�o������u���b�N�̗�ԍ��𗐐��Ŏ擾
            int columnNo = Random.Range(0, 10);

            //��ԍ��̃u���b�N�������ȏゾ�ƁA���̗�Ƀu���b�N�𐶐����Ȃ�
            if (BlockManager.columnBlockCount[columnNo] > 10) return;
            
            //��ԍ��̃u���b�N��������Z
            BlockManager.columnBlockCount[columnNo] += 1;

            //�l���Ƃɏo���ʒu�𒲐�
            int randPositionX = columnNo * 10 - 45;

            //�u���b�N�̐���
            GameObject obj = Instantiate(block, blockParent);

            //���������u���b�N�̈ʒu��ݒ�
            obj.transform.position = new Vector3(randPositionX, 200, 0);

            //�^�C���J�E���g���ăZ�b�g
            timeCount = 300;
        }
    }
}
