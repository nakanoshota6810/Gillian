using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���X�e�[�^�X���Ƃ�UI�̊Ǘ�
/// </summary>
public class UIManager
{
    //�Q�[���I����ʎ��ɕ\������UI���i�[
    [SerializeField] private GameObject gameTitleUI;

    //�Q�[���J�n���ɕ\������UI���i�[
    [SerializeField] private GameObject gameStartUI;

    //�Q�[���I�[�o�[���ɕ\������UI���i�[
    [SerializeField] private GameObject gameResultScoreUI;

    //�Q�[�����ɕ\������UI���i�[
    [SerializeField] private GameObject gameInPlayScoreUI;

    //�Q�[���X�e�[�^�X�̕ύX�����m����ϐ��̐錾
    private GameStatus nowGameStatus;

    // Start is called before the first frame update
    void Start()
    {
        nowGameStatus = GameStatus.Nome;
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���X�e�[�^�X���ύX�����Ƃ��ɏ������s��
        if (nowGameStatus != GameManager.gameStatus)
            ChangeUI();
    }

    /// <summary>
    /// �Q�[���X�e�[�^�X���Ƃ�UI�̐؂�ւ����s��
    /// </summary>
    void ChangeUI()
    {
        switch (GameManager.gameStatus)
        {
            case GameStatus.Title:
                gameTitleUI.SetActive(true);
                break;

            case GameStatus.Ready:
                gameTitleUI.SetActive(false);
                gameStartUI.SetActive(true);
                break;

            case GameStatus.InGameNormal:
                gameStartUI.SetActive(false);
                gameInPlayScoreUI.SetActive(true);
                break;

            case GameStatus.InGameWarning:
                break;

            case GameStatus.GameOver:
                gameInPlayScoreUI.SetActive(false);
                gameResultScoreUI.SetActive(true);
                break;

            default:
                break;
        }

        nowGameStatus = GameManager.gameStatus;
    }
}
