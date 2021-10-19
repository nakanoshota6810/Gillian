using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�u���b�N�̋@�\
/// </summary>
public class BlockData : MonoBehaviour
{
    //�u���b�N�̓ݑ����̋�C��R�l
    [SerializeField] private int blockDrag;

    //�u���b�N�̃X�|�[����Ԃ̈ێ�����
    private int blockSpawnTime;

    //�u���b�N�̐F
    private int blockColor;

    //�u���b�N��Rigidbory���i�[����ϐ���錾
    private new Rigidbody rigidbody;

    //�u���b�N��Renderer���i�[����ϐ���錾
    private new Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        //�e�R���|�[�l���g���擾
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        //�u���b�N�̐F�𗐐��ŕύX����
        blockColor = 0;
        RandomBlockColor();

        //�݉��܂ł̒l��������
        blockSpawnTime = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        //�u���b�N���������Ă����莞�Ԍo�߂�����A�������x��ݑ��ɂ���
        if (blockSpawnTime <= 0 && this.tag == "SpawnBlock")
        {
            //�^�O�ƃ��C���[��ݑ��p�̂��̂ɕύX
            this.tag = "AliveBlock";
            this.gameObject.layer = 6;

            //�������Ɏ󂯂��C��R�̒l���㏸������
            rigidbody.drag = blockDrag;
        }
        //SpawnBlock�^�O�̂݁A�J�E���g�_�E����i�߂�
        else if (this.tag == "SpawnBlock")
        {
            blockSpawnTime--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //�u���b�N��SpawnLine�𒴂�����A�������x��ݑ��ɂ���
        if (collision.gameObject.tag=="SpownLine" && this.tag == "SpawnBlock")
        {
            //�^�O�ƃ��C���[��ݑ��p�̂��̂ɕύX
            this.tag = "AliveBlock";
            this.gameObject.layer = 6;

            //�������Ɏ󂯂��C��R�̒l���㏸������           
            rigidbody.drag = blockDrag;
        }

        //�ʂƐڐG���̂ݏ����ɓ���
        if(collision.gameObject.tag == "Player")
        {
            //�ʂƃu���b�N�̐F�������ł���΁A�u���b�N�͏��ł���
            BallController ball = collision.gameObject.GetComponent<BallController>();
            if (ball.ballColor == blockColor)
                Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// �u���b�N�̐F�𗐐��Ō��肷��
    /// </summary>
    private void RandomBlockColor()
    {
        //�u���b�N�̐F�ԍ��𗐐��Ŏw��
        blockColor = Random.Range(0, 3);

        switch (blockColor)
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
