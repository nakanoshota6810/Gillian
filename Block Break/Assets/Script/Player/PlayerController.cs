using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�R���g���[���@�\
/// </summary>
public class PlayerController : MonoBehaviour
{
    //�v���C���[�̈ړ����x��ݒ�
    [SerializeField] private float moveSpeed = 1.0f;

    //�v���C���[�̐F���؂�ւ�鎞�Ԃ��Ǘ�����C���X�^���X
    private Timer colorChangeTime;

    //�v���C���[�̐F�����i�[
    public ColorPallet playerColor { get; private set; }

    //Renderer���i�[����C���X�^���X��錾
    private new Renderer renderer;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̃|�W�V�������i�[
        Vector3 vec = transform.position;

        //�L�[���͂ō��E�Ɉړ�����(-40�`40�͈̔�)
        //�E�Ɉړ�
        if (Input.GetKey(KeyCode.D) && transform.position.x < (GameManager.gameMode == GameMode.WideMode ? 70 : 40))
            transform.position += new Vector3(1.0f, 0, 0) * moveSpeed * Time.deltaTime * 100;
        //���Ɉړ�
        else if (Input.GetKey(KeyCode.A) && transform.position.x > (GameManager.gameMode == GameMode.WideMode ? -70 : -40))
            transform.position += new Vector3(-1.0f, 0, 0) * moveSpeed * Time.deltaTime * 100;


        //Waring���C���𒴂�����A�v���C���[�͏���
        if (GameManager.gameStatus == GameStatus.InGameWarning) 
            this.gameObject.SetActive(false);


        //�^�C���J���[�Q�[�����[�h�̎��ɏ������s����
        if (GameManager.gameMode == GameMode.TimeColorMode)
        {
            //�^�C�}�[�������Ă��Ȃ��ꍇ�́A�������B
            if (colorChangeTime == null)
            {
                colorChangeTime = new Timer(6);
                playerColor = ColorPallet.Red;
                ChacgePlayerColor();
            }

            //���J�E���g���ƂɃv���C���[�̐F��ύX����
            if (colorChangeTime.ChackTime())
            {
                int color = (int)playerColor - 1;
                color++;
                playerColor = (ColorPallet)(color % 3) + 1;
                ChacgePlayerColor();
            }
        }
    }


    /// <summary>
    /// �v���C���[�̐F��ύX����
    /// </summary>
    private void ChacgePlayerColor()
    {
        switch (playerColor)
        {
            case ColorPallet.Red:
                renderer.material.color = Color.red;
                break;

            case ColorPallet.Green:
                renderer.material.color = Color.green;
                break;

            case ColorPallet.Blue:
                renderer.material.color = Color.blue;
                break;
        }
    }
}
