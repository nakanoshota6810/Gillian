using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�Q�̊Ǘ��@�\
/// �ÓI�����ŊǗ����s��
/// </summary>
public class StageBlockManager : MonoBehaviour
{
    //�X�|�[������u���b�N���i�[����
    [SerializeField] private GameObject block = null;

    //���������ʂ̃u���b�N���C���X�y�N�^�[�Ɉڂ��Ȃ��悤�ɂ���A�u���b�N�Q�̐e
    [SerializeField] private Transform blockParent;

    //�ÓI�֐��p�̃X�|�[������u���b�N���i�[����ϐ�
    static private GameObject staticBlock = null;

    //�ÓI�֐��p�̃u���b�N�Q�̐e���i�[����ϐ�
    static private Transform staticBlockParent = null;

    //�u���b�N�Q���i�[����ÓI���X�g�ϐ���錾
    static public List<GameObject> blockList = new List<GameObject>();

    //�񂲂Ƃ̃u���b�N���������i�[����ÓI���X�g�ϐ���錾
    static public List<int> columnBlockCount = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        ////�ŏ��Ƀu���b�N���X�g������������
        //foreach (GameObject block in blockList)
        //{
        //    Destroy(block);
        //}
        blockList.Clear();
        columnBlockCount.Clear();

        //�ÓI�ϐ��Ɋ���ڂ�
        staticBlock = block;
        staticBlockParent = blockParent;

        ////�ŏ��Ɉ�����u���b�N�𐶐����A���X�g�ɒǉ�����
        //GameObject obj = Instantiate(staticBlock, staticBlockParent);
        //blockList.Add(obj);
    }

    /// <summary>
    /// �g�p����Ă��Ȃ��u���b�N��Ԃ�
    /// </summary>
    /// <returns></returns>
    static public Block GetSleepBlock()
    {
        Block itBlock = null;

        //��A�N�e�B�u��Ԃ̃u���b�N���A���X�g���猩������Ԃ�
        foreach (GameObject block in blockList)
        {
            itBlock = block.GetComponent<Block>();
            if (!itBlock.GetBlockActive())
                return itBlock;
        }

        //��A�N�e�B�u��Ԃ����X�g�Ɉ���Ȃ��ꍇ�A�V���Ƀu���b�N�𐶐�����
        GameObject obj = Instantiate(staticBlock, staticBlockParent);
        itBlock = obj.GetComponent<Block>();

        blockList.Add(obj);

        //���������u���b�N��Ԃ�
        return itBlock;
    }
}
