using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�e�[�W�S�̂̊Ǘ��@�\
/// </summary>
public class StageManager : MonoBehaviour
{
    //�X�e�[�W���̋@�\���Ǘ�����N���X��錾
    private StageFunction stageFunction;

    private void Start()
    {
        stageFunction = new StageFunction();
        stageFunction.ItStart();
    }

    private void Update()
    {
        stageFunction.ItUpdate();
    }

}


