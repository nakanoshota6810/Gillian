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

    private TimeCountChack colorChangeTime;

    public int playerColor { get; private set; }

    private new Renderer renderer;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
        playerColor = 0;
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
        if (GameManager.statusNo == MainGameStatus.InGameWarning) 
            this.gameObject.SetActive(false);


        if (GameManager.gameMode == GameMode.TimeColorMode)
        {
            if (colorChangeTime == null)
            {
                colorChangeTime = new TimeCountChack(10);
                ChacgePlayerColor();
            }

            if (colorChangeTime.ChackTime())
            {

                playerColor = Random.Range(1, 99);
                playerColor = playerColor % 3;

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
            case 0:
                //�u���b�N�̐F��ԂɕύX
                renderer.material.color = Color.red;
                break;

            case 1:
                //�u���b�N�̐F��΂ɕύX
                renderer.material.color = Color.green;
                break;

            case 2:
                //�u���b�N�̐F��ɕύX
                renderer.material.color = Color.blue;
                break;
        }
    }
}
