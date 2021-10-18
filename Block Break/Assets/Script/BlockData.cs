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

    //�u���b�N�̐F
    private int blockColor;

    //�u���b�N�̃X�|�[����Ԃ̈ێ�����
    private int blockSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        blockColor = 0;
        blockSpawnTime = 3000;
        RandomBlockColor();
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
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.drag = blockDrag;
        }
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
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.drag = blockDrag;
        }
    }

    /// <summary>
    /// �u���b�N�̐F�𗐐��Ō��肷��
    /// </summary>
    private void RandomBlockColor()
    {
        //�u���b�N�̐F�ԍ��𗐐��Ŏw��
        blockColor = Random.Range(1, 4);

        switch (blockColor)
        {
            case 1:
                //�u���b�N�̐F��΂ɕς���
                GetComponent<Renderer>().material.color = Color.green;
                break;

            case 2:
                //�u���b�N�̐F��Ԃɕς���
                GetComponent<Renderer>().material.color = Color.red;
                break;

            case 3:
                //�u���b�N�̐F��ɕς���
                GetComponent<Renderer>().material.color = Color.blue;
                break;
        }

    }
}
