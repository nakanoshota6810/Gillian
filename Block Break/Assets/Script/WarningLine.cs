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

    private void Start()
    {
        //Renderer�^�̃R���|�[�l���g���擾
        renderer = GetComponent<Renderer>();

        //�^�C���J�E���g�̏�����
        flashingTime = 500;
    }

    void Update()
    {
        //�Q�[���X�e�[�^�X���댯��Ԃ̂݁A�^�C���J�E���g�𓮂���
        if (GameManager.statusNo == MainGameStatus.InGameWarning) flashingTime--;

        //�^�C���J�E���g���ƂɁA�e�L�X�g��_�ł�����
        if (flashingTime <= 0) flashingTime = 500;
        else if (flashingTime < 250) renderer.material.color = Color.yellow;
        else renderer.material.color = Color.red;
    }

    /// <summary>
    /// �Q�[���I�[�o�[���C�����u���b�N���ʉ߂����Ƃ��A�Q�[���I�[�o�[�ɂ���
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //�u���b�N�����蔲�������̂݁A�@�\����
        if (other.gameObject.tag == "AliveBlock" && GameManager.statusNo != MainGameStatus.GameOver)
            GameManager.statusNo = MainGameStatus.InGameWarning;
        
    }
}
