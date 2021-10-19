using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //�ʂ̑�����ݒ�
    [SerializeField] private float ballSpeed = 1.0f;

    //�ʂ̐F��ԍ��Ŋi�[����ϐ�
    public int ballColor { get; private set; }

    //�ʂ�Rigidbory���i�[����ϐ���錾
    private new Rigidbody rigidbody;

    //�ʂ�Renderer���i�[����ϐ���錾
    private new Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��ɉE�΂ߏ�ֈړ����x���̓��͂��v�Z
        Vector3 force = new Vector3(1.0f, 1.0f, 0) * ballSpeed * 100;

        //�e�R���|�[�l���g���擾
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        //�ʂɗ͂�������
        rigidbody.AddForce(force);

        //�ʂ̐F�̏����ݒ�(��)
        ballColor = 0;
        renderer.material.color = Color.red;

    }

    private void Update()
    {
        //���N���b�N���Ƃɋʂ̐F��ς���
        if (Input.GetMouseButtonDown(0))
        {
            ballColor++;
            ballColor = ballColor % 3;

            //�ԍ����Ƃɋʂ̐F��ύX����
            RandomBlockColor();
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



            //�^���Ɛ^�c�Ɉړ����Ȃ��悤�ɏ���
            if ((chackX > chackY ? chackX - chackY : chackY - chackX) > 30 * ballSpeed)
            {
                vec.x += 4 * ballSpeed;
                vec.y -= 4 * ballSpeed;
            }

            //�v�Z��̒l���AVelocity�ɓn��
            rigidbody.velocity = vec;
        }

    }

    /// <summary>
    /// �ʂ̐F��ύX����
    /// </summary>
    private void RandomBlockColor()
    {
        switch (ballColor)
        {
            case 0:
                //�u���b�N�̐F��Ԃɕς���
                renderer.material.color = Color.red;
                break;

            case 1:
                //�u���b�N�̐F��΂ɕς���
                renderer.material.color = Color.green;
                break;

            case 2:
                //�u���b�N�̐F��ɕς���
                renderer.material.color = Color.blue;
                break;
        }
    }
}
