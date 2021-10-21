using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ʃR���g���[���@�\
/// </summary>
public class BallController : MonoBehaviour
{
    //�ʂ̑�����ݒ�
    [SerializeField] private float ballSpeed = 1.0f;

    [SerializeField] private PlayerController playerController;

    //�ʂ̐F��ԍ��Ŋi�[����ϐ�
    public ColorPallet ballColor { get; private set; }

    //�ʂ�Rigidbory���i�[����ϐ���錾
    private new Rigidbody rigidbody;

    //�ʂ�Renderer���i�[����ϐ���錾
    private new Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        //�e�R���|�[�l���g���擾
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        //�ʂ̐F�̏����ݒ�(��)
        ballColor = 0;
        renderer.material.color = Color.red;
    }

    private void Update()
    {
        //�ʂ���ʊO�̉��܂ŗ��������A�Q�[���I�[�o�[
        if(transform.position.y < -45)
        {
            //�Q�[���X�e�[�^�X���Q�[���I�[�o�[�ɕύX
            GameManager.statusNo = MainGameStatus.GameOver;

            //�ʂ����ł�����
            this.gameObject.SetActive(false);
        }

        //���N���b�N���Ƃɋʂ̐F��ς���
        if (Input.GetMouseButtonDown(0))
        {
            //�ŏ��̃����N���b�N�ŃQ�[�����J�n
            if (GameManager.statusNo == MainGameStatus.Ready)
            {
                //�ŏ��ɉE�΂ߏ�ֈړ����x���̓��͂��v�Z
                Vector3 force = new Vector3(1.0f, 1.0f, 0) * ballSpeed * 100;
                //�ʂɗ͂�������
                rigidbody.AddForce(force);

                //�Q�[���X�e�[�^�X���C���Q�[���ɕύX
                GameManager.statusNo = MainGameStatus.InGameNormal;
                return;
            }

            if (GameManager.gameMode != GameMode.TimeColorMode)
            {
                //�ʂ̐F�ԍ���ύX(�ԁ��΁�����)
                int colorNo = (int)ballColor - 1;
                colorNo++;
                ballColor = (ColorPallet)(colorNo % 3 + 1);

                //�ԍ����Ƃɋʂ̐F��ύX
                RandomBlockColor();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�ʂ̈ړ����x���Ƃ́A���x���ݒ�
        float ballVelocityBase = ballSpeed * 40.0f;

        //�ʂ�Velocity��X����Y���̈ړ����x���A���ׂĐ��̒l�ɂ���
        Vector3 vec = rigidbody.velocity;
        float chackX = vec.x > 0 ? vec.x : vec.x * (-1);
        float chackY = vec.y > 0 ? vec.y : vec.y * (-1);

        //�ʂ̈ړ����x����������Ă���Ȃ�A�C����������
        if ((chackX + chackY < ballVelocityBase || chackX + chackY > ballVelocityBase + 1.0f) && chackX + chackY > 0)
        {
            //X����Y���̈ړ����x�̔䗦���v�Z
            float percent = chackX + chackY;
            float perX = vec.x / percent;
            float perY = vec.y / percent;

            //��l�ɂ��ꂼ��䗦�������A�ړ����x���Z�o
            vec.x = ballVelocityBase * perX;
            vec.y = ballVelocityBase * perY;

            chackX = vec.x > 0 ? vec.x : vec.x * (-1);
            chackY = vec.y > 0 ? vec.y : vec.y * (-1);

            //�Ȃ�ׂ��A�^���Ɛ^�c�Ɉړ����Ȃ��悤�ɏ���
            if ((chackX > chackY ? chackX - chackY : chackY - chackX) > 30 * ballSpeed)
            {
                vec.x += 5 * ballSpeed;
                vec.y -= 5 * ballSpeed;
            }

            //�v�Z��̒l���AVelocity�ɓn��
            rigidbody.velocity = vec;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"&&GameManager.gameMode==GameMode.TimeColorMode)
        {
            ballColor = (ColorPallet)(playerController.playerColor+1);
            RandomBlockColor();
        }
    }

    /// <summary>
    /// �ʂ̐F��ύX����
    /// </summary>
    private void RandomBlockColor()
    {
        switch (ballColor)
        {
            case ColorPallet.Red:
                //�u���b�N�̐F��ԂɕύX
                renderer.material.color = Color.red;
                break;

            case ColorPallet.Green:
                //�u���b�N�̐F��΂ɕύX
                renderer.material.color = Color.green;
                break;

            case ColorPallet.Blue:
                //�u���b�N�̐F��ɕύX
                renderer.material.color = Color.blue;
                break;
        }
    }
}
