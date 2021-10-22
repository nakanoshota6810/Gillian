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

    //�v���C���[�̏����i�[����
    [SerializeField] private PlayerController playerController;

    //�ʂ̐F���Ǘ�����ϐ���錾
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
        ballColor = ColorPallet.Red;
        renderer.material.color = Color.red;
    }


    private void Update()
    {
        //���N���b�N���Ƃɋʂ̐F��ς���
        if (Input.GetMouseButtonDown(0))
        {
            //�Q�[���J�n���ɁA�e�ɓ��͂�^���鏈��
            ClickGameStart();

            //�N���b�N���ɋʂ̐F��ς��鏈��
            ClickChangeBallColor();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�ʂ������������菈��
        UnderFall();

        //�ʂ̈ړ�����
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�Q�[�����[�h���^�C���J���[���[�h�̎��̂݁A�v���C���[�ɐڐG���邱�ƂŁA�ʂ̐F���v���C���[�̐F�ɕω�����
        if (collision.gameObject.tag == "Ball" && GameManager.gameMode == GameMode.TimeColorMode)
        {
            ballColor = playerController.playerColor;

            //�ʂ̐F��ύX
            ChangeBlockColor();
        }
    }

    /// <summary>
    /// �Q�[���J�n���s���Ɠ����ɁA�ʂ�ł��グ�鏈��
    /// </summary>
    void ClickGameStart()
    {
        //�ŏ��̃����N���b�N�ŃQ�[�����J�n
        if (GameManager.gameStatus == GameStatus.Ready)
        {
            //�ŏ��ɉE�΂ߏ�ֈړ����x���̓��͂��v�Z
            Vector3 force = new Vector3(1.0f, 1.0f, 0) * ballSpeed * 100;
            //�ʂɗ͂�������
            rigidbody.AddForce(force);

            //�Q�[���X�e�[�^�X���C���Q�[���ɕύX
            GameManager.gameStatus = GameStatus.InGameNormal;
            return;
        }
    }

    /// <summary>
    /// ���N���b�N���A�ʂ̐F��ύX���鏈��
    /// </summary>
    void ClickChangeBallColor()
    {
        //�^�C���J���[���[�h�ȊO�ŏ������s��
        if (GameManager.gameMode != GameMode.TimeColorMode)
        {
            //�ʂ̐F�ԍ���ύX(�ԁ��΁�����)
            int colorNo = (int)ballColor - 1;
            colorNo++;
            ballColor = (ColorPallet)(colorNo % 3 + 1);

            //�ʂ̐F��ύX
            ChangeBlockColor();
        }
    }

    /// <summary>
    /// �ʂ���ʊO�܂ŗ��������ꍇ�̏���
    /// </summary>
    void UnderFall()
    {
        //�ʂ���ʊO�̉��܂ŗ��������A�Q�[���I�[�o�[
        if (transform.position.y < -45)
        {
            //�Q�[���X�e�[�^�X���Q�[���I�[�o�[�ɕύX
            GameManager.gameStatus = GameStatus.GameOver;

            //�ʂ����ł�����
            this.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// �ʂ̈ړ����Ǘ����鏈��
    /// </summary>
    void Move()
    {
        //�ʂ̈ړ����x���Ƃ́A���x��l��ݒ�
        float ballVelocityBase = ballSpeed * 40.0f;

        //����p�ɁA�ʂ�Velocity��X����Y���̈ړ����x�́A���̒l���v�Z
        Vector3 vec = rigidbody.velocity;
        float chackX = vec.x > 0 ? vec.x : vec.x * (-1);
        float chackY = vec.y > 0 ? vec.y : vec.y * (-1);

        //�ʂ̈ړ����x����ʂ�łȂ��Ȃ�A�C����������
        if ((chackX + chackY < ballVelocityBase || chackX + chackY > ballVelocityBase + 1.0f) && chackX + chackY > 0)
        {
            //X����Y���̈ړ����x�̔䗦���v�Z
            float percent = chackX + chackY;
            float perX = vec.x / percent;
            float perY = vec.y / percent;

            //���x��l�ɂ��ꂼ��䗦�������A�ړ����x���Z�o
            vec.x = ballVelocityBase * perX;
            vec.y = ballVelocityBase * perY;

            //����p�ɍēx�AX����Y���̈ړ����x�̐��̒l���v�Z
            chackX = vec.x > 0 ? vec.x : vec.x * (-1);
            chackY = vec.y > 0 ? vec.y : vec.y * (-1);

            //�Ȃ�ׂ��A�^���Ɛ^�c�Ɉړ����Ȃ��悤�ɏ���
            if ((chackX > chackY ? chackX - chackY : chackY - chackX) > 30 * ballSpeed)
            {
                //�������΂߂ɌX����
                vec.x += 5 * ballSpeed;
                vec.y -= 5 * ballSpeed;
            }

            //�v�Z��̒l���AVelocity�ɓn��
            rigidbody.velocity = vec;
        }
    }


    /// <summary>
    /// �ʂ̐F��ύX����
    /// </summary>
    private void ChangeBlockColor()
    {
        switch (ballColor)
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
