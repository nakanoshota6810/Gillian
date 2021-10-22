using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̐F���̋@�\���Ǘ�����
/// </summary>
public class BlockColorFunction
{
    //�u���b�N�̐F���̋@�\�̐e�N���X
    BlockColorFunctionBase blockColorFanctionBase;

    //�u���b�N��Renderer���i�[����
    private Renderer renderer;

    //�u���b�N��BlockData���i�[����
    private BlockData blockData;

    //�u���b�N�̐F�̕ύX�����m����ϐ��̐錾
    private ColorPallet nowColor;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param ���g��Renderer�̃C���X�^���X="rr"></param>
    /// <param ���g��BlockData�̃C���X�^���X="bd"></param>
    public BlockColorFunction(Renderer rr, BlockData bd)
    {
        renderer = rr;
        blockData = bd;
    }

    /// <summary>
    /// �ʂƐڐG�����Ƃ��̍X�V����
    /// </summary>
    /// <param �ʂ̓����蔻��="collision"></param>
    public void HitUpdate(Collision collision)
    {
        if (blockColorFanctionBase != null)
            blockColorFanctionBase.HitUpdate(collision);
    }

    /// <summary>
    /// ���������̃u���b�N�̐F�ύX
    /// </summary>
    public void StartChangeColor()
    {
        //�������Ƀu���b�N�̐F�������_���ɂ���
        int color = Random.Range(0, 3);
        blockData.blockColor = (ColorPallet)(color + 1);

        //���݂̃u���b�N�̐F���i�[
        nowColor = blockData.blockColor;

        //�F���Ƃɋ@�\��ύX
        ChangeBlockColorFunction();
    }

    /// <summary>
    /// �u���b�N�̐F�X�e�[�^�X���ɋ@�\��ύX���鏈��
    /// </summary>
    public void ItUpdate()
    {
        if (nowColor != blockData.blockColor)
            ChangeBlockColorFunction();
    }

    /// <summary>
    /// �u���b�N�̐F���ƂɁABlockColorFunctionBase���I�[�o�[���C�h����
    /// </summary>
    private void ChangeBlockColorFunction()
    {
        switch (blockData.blockColor)
        {
            case ColorPallet.Red:
                if (blockColorFanctionBase as BlockColorFunctionRed == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionRed(renderer, blockData);
                }
                break;

            case ColorPallet.Green:
                if (blockColorFanctionBase as BlockColorFunctionGreen == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionGreen(renderer, blockData);
                }
                break;

            case ColorPallet.Blue:
                if (blockColorFanctionBase as BlockColorFunctionBlue == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionBlue(renderer, blockData);
                }
                break;

            case ColorPallet.Yellow:
                if (blockColorFanctionBase as BlockColorFunctionYellow == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionYellow(renderer, blockData);
                }
                break;

            case ColorPallet.Magenta:
                if (blockColorFanctionBase as BlockColorFunctionMagenta == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionMagenta(renderer, blockData);
                }
                break;

            case ColorPallet.Cyan:
                if (blockColorFanctionBase as BlockColorFunctionCyan == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionCyan(renderer, blockData);
                }
                break;

            default:
                blockColorFanctionBase = null;
                break;
        }

        if (blockColorFanctionBase != null) blockColorFanctionBase.ChangeBlockColor();
         nowColor = blockData.blockColor;
    }
}
