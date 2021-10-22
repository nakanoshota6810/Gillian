using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockFunctionBase�փI�[�o�[���C�h���s��
/// �u���b�N�̃X�e�[�^�X���uSpawn�v���̏������s��
/// </summary>
public class BlockFunctionSpawn : BlockFunctionBase
{
    //Rigidboby���i�[����ϐ���錾
    private Rigidbody rigidbody;

    //�u���b�N�̃X�|�[����Ԃ̈ێ�����
    private Timer blockSpawnTime;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param �e�N���X�֓n�����g��BlockData�̃C���X�^���X="bd"></param>
    /// <param ���g��Rigidbody�̃C���X�^���X="bcf"></param>
    public BlockFunctionSpawn(Rigidbody rb, BlockData bd) :base(bd)
    {
        rigidbody = rb;
    }

    /// <summary>
    /// ����������
    /// </summary>
    public override void ItStart()
    {
        

        rigidbody.drag = 0;
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    public override void ItUpdate()
    {
        //�C���Q�[�����ɓݑ����^�C�}�[������
        if (GameManager.gameStatus == GameStatus.InGameNormal && blockSpawnTime != null)
        {
            //�݉��܂ł̒l��������
            blockSpawnTime = new Timer(5);
        }

        if (blockSpawnTime == null) return;

        if (blockSpawnTime.ChackTime())
        {
            //�^�O�ƃ��C���[��ݑ��p�̂��̂ɕύX
            blockData.blockStatus = BlockStatus.Alive;
      
            //�������Ɏ󂯂��C��R�̒l���㏸������
            rigidbody.drag = 6;
        }
    }

    /// <summary>
    /// �����蔻�菈��
    /// </summary>
    /// <param ������̑Ώ�="collision"></param>
    public override void ItCollisionEnter(Collision collision)
    {
        //�u���b�N��SpawnLine�𒴂�����A�������x��ݑ��ɂ���
        if (collision.gameObject.tag == "SpawnLine")
        {
            //�^�O�ƃ��C���[��ݑ��p�̂��̂ɕύX
            blockData.blockStatus = BlockStatus.Alive;

            //�������Ɏ󂯂��C��R�̒l���㏸������           
            rigidbody.drag = 6;
        }
    }
}
