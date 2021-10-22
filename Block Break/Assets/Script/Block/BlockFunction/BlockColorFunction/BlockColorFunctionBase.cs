using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̐F���Ƃ̋@�\�̐e�N���X
/// </summary>
public abstract class BlockColorFunctionBase : IBlockColorFunction
{
    //�u���b�N��Renderer���i�[����
    protected Renderer renderer;

    //�u���b�N��BlockData���i�[����
    protected BlockData blockData;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param ���g��Renderer�̃C���X�^���X="rr"></param>
    /// <param ���g��BlockData�̃C���X�^���X="bd"></param>
    public BlockColorFunctionBase(Renderer rr, BlockData bd)
    {
        renderer = rr;
        blockData = bd;
    }

    /// <summary>
    /// �e�@�\���ƂɁA�u���b�N�̐F��ύX���鏈��
    /// </summary>
    public abstract void ChangeBlockColor();

    /// <summary>
    /// �ʂƐڐG���̐F���Ƃ̏���
    /// </summary>
    /// <param �ʂ̓����蔻��="collision"></param>
    public abstract void HitUpdate(Collision collision);

}