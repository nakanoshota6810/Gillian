using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�Q�̊Ǘ��@�\
/// </summary>
public class BlockManager : MonoBehaviour
{
    //�񂲂Ƃ̃u���b�N���������i�[���郊�X�g�ϐ���錾
    static public List<int> columnBlockCount;

    public int timeCount { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 1000;
        columnBlockCount = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (--timeCount <= 0)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int log = columnBlockCount[i];
        //        Debug.Log(log);
        //    }

        //    timeCount = 1000;
        //}
    }
}
