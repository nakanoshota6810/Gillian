using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�̃X�e�[�^�X���̃C���^�[�t�F�[�X
/// </summary>
public interface IBlockFunction
{
    public void ItStart();
    public void ItUpdate();
    public void ItCollisionEnter(Collision collision);

}
