using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̃X�e�[�^�X���̋@�\�̐e�N���X
/// </summary>
public abstract class BlockFunctionBase : IBlockFunction
{
    protected BlockData blockData;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param ���g��BlockData�̃C���X�^���X="bd"></param>
    public BlockFunctionBase(BlockData bd)
    {
        blockData = bd;
    }

    public abstract void ItStart();
    public abstract void ItUpdate();
    public abstract void ItCollisionEnter(Collision collision);
}
