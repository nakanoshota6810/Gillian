using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���J�n���̃u���b�N�Q�̔z�u�@�\
/// </summary>
public class BlockSetStart : MonoBehaviour
{
    //�X�|�[������u���b�N���i�[����
    [SerializeField] private GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���J�n���A�܂Ƃ܂����u���b�N�Q�𐶐�����
        for(int column = 0; column < 10; column++)
        {
            for(int line = 0; line < 5; line++)
            {
                //�u���b�N�̐���
                GameObject obj = Instantiate(block);

                //���������u���b�N�̈ʒu��ݒ�
                obj.transform.position = new Vector3(column * 10 - 45, line * 10 + 110, 0);

            }

            //�񂲂Ƃ̃u���b�N�̐��������i�[
            BlockManager.columnBlockCount.Add(5);
        }
    }
}
