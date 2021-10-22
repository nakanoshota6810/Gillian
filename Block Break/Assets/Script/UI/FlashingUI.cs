using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI�̓_�ł��Ǘ�
/// </summary>
public class FlashingUI : MonoBehaviour
{
    //�_�ł�����e�L�X�g��ݒ�
    [SerializeField] private Text gameStartConditionText = null;

    //�_�ł̊�ƂȂ�^�C���J�E���g���i�[����ϐ���錾
    private int flashingTime;

    // Start is called before the first frame update
    void Start()
    {
        //�^�C���J�E���g�̏�����
        flashingTime = 300;
    }

    // Update is called once per frame
    void Update()
    {
        flashingTime--;

        //�^�C���J�E���g���ƂɁA�e�L�X�g��_�ł�����
        if (flashingTime <= 0) flashingTime = 300;
        else if (flashingTime < 70) gameStartConditionText.gameObject.SetActive(false);
        else gameStartConditionText.gameObject.SetActive(true);
    }
}
