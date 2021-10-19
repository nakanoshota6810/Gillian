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

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̃|�W�V�������i�[
        Vector3 vec = transform.position;

        //�L�[���͂ō��E�Ɉړ�����(-40�`40�͈̔�)
        //�E�Ɉړ�
        if (Input.GetKey(KeyCode.D) && transform.position.x < 40)
            transform.position += new Vector3(1.0f, 0, 0) * moveSpeed * Time.deltaTime * 100;
        //���Ɉړ�
        else if (Input.GetKey(KeyCode.A) && transform.position.x > -40)
            transform.position += new Vector3(-1.0f, 0, 0) * moveSpeed * Time.deltaTime * 100;


        //Waring���C���𒴂�����A�v���C���[�͏���
        if (GameManager.statusNo == MainGameStatus.InGameWarning) 
            this.gameObject.SetActive(false);

    }
}
