using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InPlayScoreUI : MonoBehaviour
{
    //�Q�[����ʂɏo���R���{�e�L�X�g���i�[
    [SerializeField] private Text inPlayComboCountUIText;

    private void Start()
    {
        //�R���{�J�E���g���e�L�X�g�ɋL��
        inPlayComboCountUIText.text = Score.comboCount + " �R���{";
    }

    // Update is called once per frame
    void Update()
    {
        //�R���{�J�E���g���e�L�X�g�ɋL��
        inPlayComboCountUIText.text = Score.comboCount + " �R���{";
    }
}
