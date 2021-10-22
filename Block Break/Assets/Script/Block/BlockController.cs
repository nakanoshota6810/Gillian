using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̋@�\���Ǘ�����
/// </summary>
public class BlockController
{
    //�u���b�N��Rigidbory���i�[����ϐ���錾
    private Rigidbody rigidbody;

    //�u���b�N��Renderer���i�[����ϐ���錾
    private Renderer renderer;

    //�u���b�N�̃f�[�^���i�[����ϐ���錾
    private BlockData blockData;

    //�u���b�N�̋����N���X�̃C���X�^���X���i�[����ϐ���錾
    BlockFunction blockFunction;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param ���g��Rigidbody�̃C���X�^���X="rb"></param>
    /// <param ���g��Renderer�̃C���X�^���X="rr"></param>
    /// <param ���g��BlockData�̃C���X�^���X="bd"></param>
    public BlockController(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody   = rb;
        renderer    = rr;
        blockData   = bd;

        //�u���b�N�̋����N���X���C���X�^���X��
        blockFunction = new BlockFunction(rigidbody, renderer, blockData);
    }

    /// <summary>
    /// �u���b�N���A�N�e�B�u��ԂɂȂ������̏���
    /// </summary>
    public void BlockInstantiate()
    {
        blockFunction.BlockInstantiate();
    }

    /// <summary>
    /// �u���b�N�̍X�V����
    /// </summary>
    public void ItUpdate()
    {
        blockFunction.ItUpdate();
    }

    /// <summary>
    /// �u���b�N�̓����蔻�菈��
    /// </summary>
    /// <param �����蔻��="collision"></param>
    public void ItCollisionEnter(Collision collision)
    {
        blockFunction.ItCollisionEnter(collision);
    }
   
}
