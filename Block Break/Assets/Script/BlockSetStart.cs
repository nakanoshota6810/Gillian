using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���J�n���̃u���b�N�Q�̔z�u�@�\
/// </summary>
public class BlockSetStart : MonoBehaviour
{
    //�X�|�[������u���b�N���i�[����
    [SerializeField] private Block block;

    //���������ʂ̃u���b�N���C���X�y�N�^�[�Ɉڂ��Ȃ��悤�ɂ���A�u���b�N�Q�̐e
    [SerializeField] private Transform blockParent;

    private bool oneCreateFlag;

    // Start is called before the first frame update
    void Start()
    {
        oneCreateFlag = false;
    }

    private void Update()
    {

        //�Q�[���J�n�O�Ɉ�x�����܂Ƃ܂����u���b�N�Q�𐶐�
        if (!oneCreateFlag && GameManager.statusNo == MainGameStatus.Ready)
        {
            int columnCount = 10;
            int halfValue = 45;
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
                    //�u���b�N�̐���
                    GameObject obj = Instantiate(block.gameObject, blockParent);

                    //���������u���b�N�̈ʒu��ݒ�
                    obj.transform.position = new Vector3(column * 10 - halfValue, line * 12 + 150, 0);

                }

                //�񂲂Ƃ̃u���b�N�̐��������i�[
                BlockManager.columnBlockCount.Add(5);

                oneCreateFlag = true;
            }
        }
    }
}
