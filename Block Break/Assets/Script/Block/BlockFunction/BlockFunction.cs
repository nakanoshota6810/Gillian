using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̐F�X�^�[�^�X���̋@�\���Ǘ�����
/// </summary>
public class BlockFunction : IBlockFunction
{
    //�u���b�N�̃X�e�[�^�X���̋@�\�̐e�N���X
    private BlockFunctionBase blockFunctionBase;

    //�u���b�N��Rigidbody���i�[����
    private Rigidbody   rigidbody;

    //�u���b�N��Renderer���i�[����
    private Renderer    renderer;

    //�u���b�N��BlockData���i�[����
    private BlockData   blockData;

    //�u���b�N�̐F���Ƃ̏����̊Ǘ��N���X
    private BlockColorFunction blockColorFunction;

    //�u���b�N�̃X�e�[�^�X�̕ύX�����m����ϐ��̐錾
    BlockStatus nowStatus;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param ���g��Rigidbody�̃C���X�^���X="rb"></param>
    /// <param ���g��Renderer�̃C���X�^���X="rr"></param>
    /// <param ���g��BlockData�̃C���X�^���X="bd"></param>
    public BlockFunction(Rigidbody rb, Renderer rr, BlockData bd)
    {
        rigidbody   = rb;
        renderer    = rr;
        blockData   = bd;

        blockColorFunction = new BlockColorFunction(renderer, blockData);

        //�u���b�N���A�N�e�B�u��ԂɕύX
        BlockInstantiate();
    }

    /// <summary>
    /// �e�X�e�[�^�X���̋@�\�̏���������
    /// </summary>
    public void ItStart() 
    {
        blockFunctionBase.ItStart();
    }

    /// <summary>
    /// �e�X�e�[�^�X���̋@�\�̍X�V����
    /// </summary>
    public void ItUpdate()
    {
        //�Q�[���X�e�[�^�X�̕ύX���s��ꂽ��A�@�\��ύX����
        if (nowStatus != blockData.blockStatus)
            ChangeBlockFunction();

        if (blockFunctionBase != null)
            blockFunctionBase.ItUpdate();

        //�F���̍X�V�������s��
        blockColorFunction.ItUpdate();
    }

   /// <summary>
   /// �X�e�[�^�X���̓����蔻�菈��
   /// </summary>
   /// <param �ʂ̓����蔻��="collision"></param>
    public void ItCollisionEnter(Collision collision)
    {
        if (blockFunctionBase != null)
            blockFunctionBase.ItCollisionEnter(collision);
    }

    /// <summary>
    /// �A�N�e�B�u��Ԃɐ؂�ւ�������̏���������
    /// </summary>
    public void BlockInstantiate()
    {
        //�e�u���b�N�̃X�e�[�^�X��������
        blockData.blockActive   = true;
        blockData.blockStatus   = BlockStatus.Spawn;
        blockData.blockTag      = "SpawnBlock";
        blockData.blockLayerNo  = 7;

        //�X�e�[�^�X���̋@�\�̕ύX
        ChangeBlockFunction();

        //�F���̋@�\�̏�����
        blockColorFunction.StartChangeColor();
    }

    /// <summary>
    /// �u���b�N�̃X�e�[�^�X���ɁABlockFunctionBase�փI�[�o�[���C�h����
    /// </summary>
    private void ChangeBlockFunction()
    {
        blockFunctionBase = null;

        switch (blockData.blockStatus)
        {
            case BlockStatus.Spawn:
                blockFunctionBase = new BlockFunctionSpawn(rigidbody, blockData);
                ItStart();
                break;

            case BlockStatus.Alive:
                blockFunctionBase = new BlockFunctionAlive(blockData, blockColorFunction);
                ItStart();
                break;

            case BlockStatus.Break:
                blockFunctionBase = new BlockFunctionBreak(blockData);
                ItStart();
                break;

            case BlockStatus.SuperBreak:
                blockFunctionBase = new BlockFunctionSuperBreak(blockData);
                ItStart();
                break;

            default:
                blockData.blockStatus = BlockStatus.None;
                break;
        }

        nowStatus = blockData.blockStatus;
    }
}
