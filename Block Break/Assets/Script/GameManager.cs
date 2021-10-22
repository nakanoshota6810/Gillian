using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// �Q�[���S�̂̊Ǘ��@�\
/// </summary>
public class GameManager:MonoBehaviour
{
    //�Q�[���X�e�[�^�X��ÓI�Ɋi�[����ϐ���錾
    static public GameStatus gameStatus { get; set; }

    //�Q�[�����[�h��ÓI�Ɋi�[����ϐ���錾
    static public GameMode gameMode { get; set; }

    //�Q�[���J�n�O�Ƀu���b�N�������ė��Ȃ��悤�A�����I�ɍǂ��v���[�g��ݒ�
    [SerializeField] private GameObject readyObject;

    //�Q�[���̍��E�̕ǂ��i�[
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;

    //�댯���C�����i�[
    [SerializeField] private GameObject flashingLine;

    private void Start()
    {
        //�Q�[���J�n���̓Q�[���X�e�[�^�X���Q�[���I����Ԃɂ���
        gameStatus = GameStatus.Title;

        //�X�R�A�̏�����
        Score.ResetScore();

        //�������Ԃ̏�����
        InternalTime.TimeReset();

        gameMode = 0;

    }

    void Update()
    {
        //�Q�[���J�n����UI�Ȃǂ��폜
        if (gameStatus == GameStatus.InGameNormal)
        {
            //�u���b�N�������Ȃ��悤�ɍǂ��ł���v���[�g��P��
            readyObject.SetActive(false);

            Score.UpdateChackComboAlive();
        }

        //�������Ԃ̍X�V
        InternalTime.TimeUpdate();
    }

    /// <summary>
    /// ���g���C������
    /// </summary>
    public void Retry()
    {
        //MainGame�V�[�����ēǂݍ���
        SceneManager.LoadScene("MainGame");
    }

    //�Q�[�����[�h�I����A�J�n�����Ɉڍs
    public void GameStart()
    {
        gameStatus = GameStatus.Ready;
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// �ʏ�Q�[�����[�h
    /// </summary>
    public void SetNormalMode()
    {
        gameMode = GameMode.NormalMode;
    }

    /// <summary>
    /// �^�C���J���[�Q�[�����[�h
    /// </summary>
    public void SetTimeColorMode()
    {
        gameMode = GameMode.TimeColorMode;
    }

    /// <summary>
    /// ���C�h�Q�[�����[�h
    /// </summary>
    public void SetWideMode()
    {
        gameMode = GameMode.WideMode;
        leftWall.transform.position = new Vector3(-85, 0, 0);
        rightWall.transform.position = new Vector3(85, 0, 0);
        flashingLine.transform.localScale = new Vector3(18, 1, 0.1f);
    }
}
