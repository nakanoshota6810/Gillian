using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���I�[�o�[���C���̋@�\
/// </summary>
public class GameOverLine : MonoBehaviour
{
    //�Q�[���I�[�o�[���C���̍����̏����l��ݒ�
    [SerializeField] private float lineUnderPositionY;


    /// <summary>
    /// �Q�[���I�[�o�[���C�����u���b�N���ʉ߂����Ƃ��A�Q�[���I�[�o�[�ɂ���
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //�u���b�N�����蔲�������̂݁A�@�\����
        if (other.gameObject.tag == "AliveBlock")
        {
            //����̓��O�̂ݕ\��
            Debug.Log("GameOver");
        }
    }
}
