using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// �Q�[���S�̂̊Ǘ��@�\
/// </summary>
public class GameManager:MonoBehaviour
{
    //�Q�[���X�e�[�^�X���i�[����ϐ���錾
    static public MainGameStatus statusNo { get; set; }

    //�Q�[���J�n���ɕ\������UI��ݒ�
    [SerializeField] private GameObject gameStartUI;

    //�Q�[���I�[�o�[���ɕ\������UI��ݒ�
    [SerializeField] private GameObject gameOverUI;

    //�Q�[���J�n�O�Ƀu���b�N�������ė��Ȃ��悤�A�����I�ɍǂ��v���[�g��ݒ�
    [SerializeField] private GameObject readyObject;

    private void Start()
    {
        //�Q�[���J�n���̓Q�[���X�e�[�^�X��������Ԃɂ���
        statusNo = MainGameStatus.Ready;
    }

    void Update()
    {
        //�Q�[���J�n����UI�Ȃǂ��폜
        if (statusNo == MainGameStatus.InGameNormal)
        {
            //UI�̍폜
            gameStartUI.SetActive(false);

            //�u���b�N�������Ȃ��悤�ɍǂ��ł���v���[�g��P��
            readyObject.SetActive(false);
        }

        //�Q�[���I�[�o�[���ɁA�Q�[���I�[�o�[UI��\��
        if (statusNo == MainGameStatus.GameOver) gameOverUI.SetActive(true);
        
    }

    /// <summary>
    /// ���g���C������
    /// </summary>
    public void Retry()
    {
        //MainGame�V�[�����ēǂݍ���
        SceneManager.LoadScene("MainGame");
    }
}
