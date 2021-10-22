using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //�u���b�N�̃f�[�^�N���X�̃C���X�^���X���i�[����ϐ���錾
    private BlockData       blockData;

    //�u���b�N�̃R���g���[���N���X�̃C���X�^���X���i�[����ϐ���錾
    private BlockController blockController;

    //�u���b�N�̃X�[�p�[�u���C�N���ɗ����Ռ��g���o�̃I�u�W�F�N�g���i�[
    [SerializeField] private GameObject effectObject;

    private void Awake()
    {
        //�u���b�N�f�[�^�N���X���C���X�^���X��
        blockData = new BlockData();

        //�R���|�[�l���g��ǂݍ���
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Renderer renderer = GetComponent<Renderer>();

        //�u���b�N�R���g���[���N���X�̃C���X�^���X��
        blockController = new BlockController(rigidbody, renderer, blockData);

        //�u���b�N�̃A�N�e�B�u��
        blockController.BlockInstantiate(); ;
    }

    // Update is called once per frame
    void Update()
    {
        //�u���b�N�̋������X�V
        blockController.ItUpdate();

        //�u���b�N�̃X�e�[�^�X���uSuperBreak�v�Ȃ�A�������s��
        if (blockData.blockStatus == BlockStatus.SuperBreak)
            BlockSuperBreak();

        //�u���b�N�f�[�^��false�Ȃ�A�u���b�N���̂��A�N�e�B�u��Ԃɂ���
        if (!blockData.blockActive)
            this.gameObject.SetActive(false);
        
        //�e�^�O�ƃ��C���[���X�V
        this.tag = blockData.blockTag;
        this.gameObject.layer = blockData.blockLayerNo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�����蔻�薈�ɏ������s��
        blockController.ItCollisionEnter(collision);
    }

    /// <summary>
    /// �u���b�N���A�N�e�B�u�������Ƃ��������s��
    /// </summary>
    /// <param �A�N�e�B�u��������ʒu���="positionVector"></param>
    public void BlockInstantiate(Vector3 positionVector)
    {
        blockData.blockActive = true;
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = positionVector;
        blockController.BlockInstantiate();
    }

    /// <summary>
    /// �u���b�N�̃A�N�e�B�u��Ԃ�Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool GetBlockActive()
    {
        return blockData.blockActive;
    }

    /// <summary>
    /// �����F�u���b�N���j�󂳂ꂽ�Ƃ��A�㍶�E�꒼���֏Ռ��g�𑖂点��(�A������)
    /// </summary>
    private void BlockSuperBreak()
    {
        //�Ռ��g�p�ɏ㉺���E�̃x�N�g���������i�[����ϐ���錾
        Vector3[] effectVector;

        //�㉺���E�̃x�N�g�����쐬
        effectVector = new Vector3[4];

        effectVector[0] = new Vector3(1, 0, 0);
        effectVector[1] = new Vector3(0, 1, 0);
        effectVector[2] = new Vector3(-1, 0, 0);
        effectVector[3] = new Vector3(0, -1, 0);

        //�O�����ɂ��ꂼ��Ռ��g�𐶐�
        for (int i = 0; i < 3; i++)
        {
            //�Ռ��g����
            GameObject obj = Instantiate(effectObject);

            //���点������Ɣj�󂳂ꂽ�u���b�N�̈ʒu��n��
            obj.GetComponent<EffectController>().SetVectors(effectVector[i], transform.position);

        }

        //�u���b�N�f�[�^�̃A�N�e�B�u����false�ɂ���
        blockData.blockActive = false; 
        blockData.blockStatus = BlockStatus.None;
    }
}
