using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �댯���C���̋@�\
/// </summary>
public class WarningLine : MonoBehaviour
{
    //�Q�[���I�[�o�[���C���̍����̏����l��ݒ�
    [SerializeField] private float lineUnderPositionY;

    //Renderer�^���i�[����ϐ���錾
    private new Renderer renderer;

    //�_�ł̊�ƂȂ�^�C���J�E���g���i�[����ϐ���錾
    private int flashingTime;

    private bool warningFlag;

    private void Start()
    {
        //Renderer�^�̃R���|�[�l���g���擾
        renderer = GetComponent<Renderer>();

        //�^�C���J�E���g�̏�����
        flashingTime = 500;

        //�_�ŏ����̃t���O�̏�����
        warningFlag = false;
    }

    void Update()
    {
        //�Q�[���X�e�[�^�X���댯��Ԃ̂݁A�^�C���J�E���g�𓮂���
        if (GameManager.gameStatus == GameStatus.InGameWarning) warningFlag = true;

        //�t���O���^�̂Ƃ��A�_�ŗp�̃^�C���J�E���g��i�߂�
        if (warningFlag) flashingTime--;

        //�^�C���J�E���g���ƂɁA�e�L�X�g��_�ł�����
        if (flashingTime <= 0) flashingTime = 500;
        else if (flashingTime < 250) renderer.material.color = Color.yellow;
        else renderer.material.color = Color.red;
    }

    /// <summary>
    /// �댯���C�����u���b�N���ʉ߂����Ƃ��A�댯��Ԃɂ���
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //�u���b�N�����蔲�������̂݁A�X�e�[�^�X�ύX
        if (other.gameObject.tag == "AliveBlock" && GameManager.gameStatus != GameStatus.GameOver)
            GameManager.gameStatus = GameStatus.InGameWarning;
        
    }
}
