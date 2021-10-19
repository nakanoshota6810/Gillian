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

    [SerializeField] private GameObject blockEffect;

    //�u���b�N�̃X�|�[����Ԃ̈ێ�����
    private int blockSpawnTime;

    //�u���b�N�̐F
    private int blockColor;

    //�u���b�N��Rigidbory���i�[����ϐ���錾
    private new Rigidbody rigidbody;

    //�u���b�N��Renderer���i�[����ϐ���錾
    private new Renderer renderer;

    private Vector3[] effectVector;


    // Start is called before the first frame update
    void Start()
    {
        //�e�R���|�[�l���g���擾
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        //�u���b�N�̐F�𗐐��ŕύX����
        blockColor = Random.Range(0, 3);
        ChangeBlockColor();

        //�݉��܂ł̒l��������
        blockSpawnTime = 3000;

        effectVector = new Vector3[4];

        effectVector[0] = new Vector3(1, 0, 0);
        effectVector[1] = new Vector3(0, 1, 0);
        effectVector[2] = new Vector3(-1, 0, 0); 
        effectVector[3] = new Vector3(0, -1, 0);
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

        if (collision.gameObject.tag == "Effect")
        {
            Destroy(this.gameObject);
        }

        //�ʂƐڐG���̂ݏ����ɓ���
        if (collision.gameObject.tag == "Player")
        {
            //�ʂƃu���b�N�̐F�������ł���΁A�u���b�N�͏��ł���
            BallController ball = collision.gameObject.GetComponent<BallController>();
            if (ball.ballColor == blockColor)
                Destroy(this.gameObject);
            else
            {
                if (blockColor < 3)
                {
                    blockColor += ball.ballColor + 2;
                    ChangeBlockColor();
                    return;
                }

                if (blockColor + ball.ballColor + 1 == 6)
                {
                    WhiteBlockBreak(transform.position);
                    Destroy(this.gameObject);
                }
            }
        }

        
       
    }

    /// <summary>
    /// �u���b�N�̐F�𗐐��Ō��肷��
    /// </summary>
    private void ChangeBlockColor()
    {

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

            case 3:
                //�u���b�N�̐F���C�G���[�ɕς���
                renderer.material.color = Color.yellow;
                break;

            case 4:
                //�u���b�N�̐F���}�[���^�ɕς���
                renderer.material.color = Color.magenta;
                break;

            case 5://�u���b�N�̐F���V�A���ɕς���
                renderer.material.color = Color.cyan;
                break;

        }
    }

    private void WhiteBlockBreak(Vector3 vec)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(blockEffect);

            obj.GetComponent<EffectController>().SetVector(effectVector[i], transform.position);

        }
    }
}
