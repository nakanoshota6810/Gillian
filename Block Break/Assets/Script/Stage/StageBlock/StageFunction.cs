using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�e�[�W�@�\�Q���Ǘ�����
/// </summary>
public class StageFunction 
{
    //�e�X�e�[�W�@�\�̐e�N���X��錾
    private StageFunctionBase stageFunctionBase;

    //�Q�[���X�e�[�^�X�̕ύX�����m����ϐ��̐錾
    GameStatus nowMainGameStatus;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public StageFunction()
    {
        nowMainGameStatus = GameManager.gameStatus;
        stageFunctionBase = null;

        //�X�e�[�W�@�\�̐؂�ւ�����
        ChangeGameStatus();
    }

    /// <summary>
    /// �X�e�[�W�@�\�̐؂�ւ���̏���������
    /// </summary>
    public void ItStart()
    {
        //�I�[�o�[���C�h����Ă��Ȃ��ꍇ�͏������s��Ȃ�
        if (stageFunctionBase != null)
            stageFunctionBase.ItStart();
    }

    /// <summary>
    /// �X�e�[�W�@�\���Ƃ̍X�V����
    /// </summary>
    public void ItUpdate()
    {
        //�Q�[���X�e�[�^�X���ύX���ꂽ�Ƃ��A�X�e�[�W�@�\��؂�ւ���
        if (nowMainGameStatus != GameManager.gameStatus)
            ChangeGameStatus();
        

        //�I�[�o�[���C�h����Ă��Ȃ��ꍇ�͏������s��Ȃ�
        if (stageFunctionBase != null)
            stageFunctionBase.ItUpdate();
    }

    /// <summary>
    /// �Q�[���X�e�[�^�X���ƂɁA�X�e�[�W�@�\���I�[�o�[���C�h�Ő؂�ւ����s��
    /// </summary>
    void ChangeGameStatus()
    {
        stageFunctionBase = null;

        switch (GameManager.gameStatus)
        {
            case GameStatus.Title:
                break;

            case GameStatus.Ready:
                stageFunctionBase = new StageFunctionSetStartBlocks();
                ItStart();
                break;

            case GameStatus.InGameNormal:
                stageFunctionBase = new StageFunctionBlockSpawn();
                ItStart();
                break;

            case GameStatus.InGameWarning:
                break;

            case GameStatus.GameOver:
                break;

            default:
                break;
        }

        nowMainGameStatus = GameManager.gameStatus;

    }
}
