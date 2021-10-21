using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�Q�̊Ǘ��@�\
/// </summary>
public class StageBlockManager : MonoBehaviour
{
    //�X�|�[������u���b�N���i�[����
    [SerializeField] private GameObject block = null;

    //���������ʂ̃u���b�N���C���X�y�N�^�[�Ɉڂ��Ȃ��悤�ɂ���A�u���b�N�Q�̐e
    [SerializeField] private Transform blockParent;

    static private GameObject staticBlock = null;

    static private Transform staticBlockParent = null;

    static public bool blockAlive = false;

    //�u���b�N�Q���i�[���郊�X�g�ϐ���錾
    static public List<GameObject> blockList = new List<GameObject>();

    //�񂲂Ƃ̃u���b�N���������i�[���郊�X�g�ϐ���錾
    static public List<int> columnBlockCount = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject block in blockList)
        {
            Destroy(block);
        }
        blockList.Clear();

        staticBlock = block;
        staticBlockParent= blockParent;

        GameObject obj = Instantiate(staticBlock, staticBlockParent);
        blockList.Add(obj);
    }

    static public Block GetSleepBlock()
    {
        Block itBlock = null;

        foreach (GameObject block in blockList)
        {
            itBlock = block.GetComponent<Block>();
            if (!itBlock.GetBlockActive())
                return itBlock;
        }

        GameObject obj = Instantiate(staticBlock, staticBlockParent);

        blockList.Add(obj);

        return itBlock;
    }
}
