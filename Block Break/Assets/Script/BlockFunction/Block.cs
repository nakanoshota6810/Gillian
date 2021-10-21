using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private BlockData       blockData;
    private BlockController blockController;



    [SerializeField] private GameObject effectObject;

    // Start is called before the first frame update
    void Start()
    {
        blockData = new BlockData();

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Renderer renderer = GetComponent<Renderer>();
        blockController = new BlockController(rigidbody, renderer,blockData);
        blockController.ItStart();
    }

    // Update is called once per frame
    void Update()
    {
        blockController.ItUpdate();

        if (blockData.blockStatus == BlockStatus.SuperBreak)
            BlockSuperBreak();

        if (!blockData.blockActive) Destroy(this.gameObject);

        this.tag = blockData.blockTag;
        this.gameObject.layer = blockData.blockLayerNo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        blockController.ItCollisionEnter(collision);
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
            obj.GetComponent<EffectController>().SetVector(effectVector[i], transform.position);

        }

        blockData.blockStatus = BlockStatus.None;
        blockData.blockActive = false;
    }
}
