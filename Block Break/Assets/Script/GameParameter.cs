using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[�����̃p�����[�^��S���L��
/// </summary>
class GameParameter :MonoBehaviour
{
    //�Q�[���I�[�o�[���C���̍����̏����l��ݒ�
    [SerializeField] private float lineUnderPositionY;
    static public float gameOverLineUnderPositionY;


    public GameParameter()
    {
        //�Q�[���I�[�o�[���C���̍����̏����l��ÓI�֐��Ɉڂ�
        gameOverLineUnderPositionY = lineUnderPositionY;






    }


}
