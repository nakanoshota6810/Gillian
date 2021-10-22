using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�R�AUI���Ǘ�
/// </summary>
public class ResultScoreUI : MonoBehaviour
{
    //�j�󂵂��u���b�N����\������e�L�X�g���i�[
    [SerializeField] Text blockBreakCountText;

    //�ő�R���{����\��������e�L�X�g���i�[
    [SerializeField] Text maxComboCountText;

    //�X�R�A��\������e�L�X�g���i�[
    [SerializeField] Text scoreText;
  
    // Start is called before the first frame update
    void Start()
    {
        //�e�X�R�A���e�L�X�g�ɋL��
        blockBreakCountText.text    = "�j�󂵂��u���b�N�� : "    + Score.blockBreakCount;
        maxComboCountText.text      = "�ő�R���{�� : "          + Score.maxComboCount;
        scoreText.text              = "�X�R�A : "                + Score.score;
    }
}
