using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�Q�̊Ǘ��@�\
/// </summary>
public class BlockManager : MonoBehaviour
{
    //�񂲂Ƃ̃u���b�N���������i�[���郊�X�g�ϐ���錾
    static public List<int> columnBlockCount = new List<int>();

    static GameObject blockEffect;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void WhiteBlockBreak(Vector3 vec)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(blockEffect);

            
        }
    }

}


